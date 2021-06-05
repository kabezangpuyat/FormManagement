<template>
  <div class="modal-form-lob" :click="beforeClose">
    <div class="title">{{isEdit? "Edit":"New"}} Case Type</div>
    
    <!-- <div style="margin:10% 25%">
      <label>DROPDOWN</label>
        <ejs-multiselect id='multiselect' :dataSource='sportsData'></ejs-multiselect>
    </div> -->
    <div class="field">
      <label>Description</label>
      <input type="text" v-model="calltype.name">
    </div>
    <div class="field">
        <label>LOB</label>
        <multiselect v-model="value" :options="lobs" :multiple="true" :close-on-select="false" :max-height="170" :clear-on-select="false" :preserve-search="true" placeholder="Select LoB(s)" label="name" track-by="id" :preselect-first="true">
          <template slot="selection" slot-scope="{ values, isOpen }"><span class="multiselect__single" v-if="values.length &amp;&amp; !isOpen">{{ values.length }} options selected</span></template>
        </multiselect>
    </div>
    <div class="form-buttons" align='left'>
      <button @click="hide" class="buttonCancel">
        <span><font-awesome-icon :icon="'times'"/> Cancel</span></button>
      <button @click="save" class="button">
        <span><font-awesome-icon :icon="'save'"/> Save</span></button>
    </div>
  </div>
  
</template>

<script>
import multiselect from 'vue-multiselect';

export default {
  components: { multiselect },
  mounted() {
    if (this.isEdit) {
      this.calltype = this.existingCallType;

      this.$store.dispatch('calltype/getCallTypeLoB', {id : this.calltype.id});
      this.value = this.$store.getters['calltype/getAllCallTypeLoB'];
    }
    
    this.lobs = this.$store.getters["lob/getAll"].lobs;
  },
  data() {
    return {
      calltype: {
        id: 0,
        calltypeId: this.calltypeId,
        description: "",
        name: ""
      },
      lobs: [],
      lobid: 0,
      value: [],
      calltypelob: {
        id: 0,
        description : "",
        LOBs : []
      }
    };
  },
  methods: {
    beforeClose(event) {
      //console.log('test');
        event.cancel()
    },
    save: function() {
      this.calltypelob.id = this.calltype.id;
      this.calltypelob.description = this.calltype.name;
      this.calltypelob.LOBs = this.value;
      
      if (this.calltype.name == "") {
        this.$toasted.error(
          "Description field is required."
        );
        return;
      }
      else if (this.value.length == 0) {
        this.$toasted.error(
          "LoB field is required."
        );
        return;
      }
      else if (this.isEdit) {
        this.$store.dispatch("calltype/update", this.calltypelob).then(() => {
          
          this.$store.dispatch('calltype/getCallTypeLoB', {id : this.calltype.id});
          this.calltype.description = this.calltype.name;
          this.$emit("close");
        });
      } else {
        this.$store.dispatch("calltype/create", this.calltypelob).then(() => {
          this.$toasted.success(
            "Case Type " + this.calltype.name + " added."
          );

          this.$emit("close");
          
        }); 
      }
    },
    hide: function() {
      this.$emit("close");
    }
  },
  props: ["calltypeId", "isEdit", "existingCallType"]
};
</script>

<style>
    /* @import url(https://cdn:syncfusion.com/ej2/material.css); */
</style>

<style>
input[type="color"] {
  padding: 0;
  border: none;
  background-color: transparent;
  outline: none;
  transform: scale(1.5);
}

.field {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  padding: 20px 0px;
}

.field > label {
  width: 100px;
}
.field > input[type="text"] {
  font-family: "Montserrat", sans-serif;
  width: 100%;
}
.button {
        background-color: rgb(37, 173, 89); 
        color: white;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        font-weight: 700;
        border-radius: 4px;
    }
.buttonCancel {
        background-color: rgb(226, 235, 229); 
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        font-weight: 700;
        border-radius: 4px;
        
    }
</style>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>