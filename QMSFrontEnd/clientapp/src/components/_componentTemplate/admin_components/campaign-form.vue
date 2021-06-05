<template>
  <div class="formview">
    <div class="title" v-if="this.campaignID==0 || this.campaignID===undefined">New Campaign</div>
    <div class="title" v-else>Edit Campaign</div>
    <div class="field">
      <label>Name</label>
      <input type="text" v-model="campaignName" placeholder="Campaign Name">
    </div>
    <div class="form-buttons">
        <button class="button" 
            v-confirm="{ok: dialog => save(dialog),
                        message:'Save data?'}">Save</button>
        <button class="button" @click="hide">Cancel</button>
        <button class="buttonDelete" v-if="this.campaignID>0" @click="remove" style="display:none;">Delete</button>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
 
  mounted() {
   if(Object.keys(this.data).length == 0){
      this.campaignID=0;
      this.campaignName='';
      alert('wala')
    }else{
      this.campaignID=this.data.id;
      this.campaignName=this.data.name;  
      alert('meron')    
    }
  },
  props:['data'],
  data() {
    return {
      campaignName:'',
      campaignID: 0
    };
  },
  methods: {
    async save(dialog) {
      var message = '';
        if (this.campaignID == 0 || this.campaignID === undefined) {
            //create or insert
            if (this.campaignName.trim() == '') {
                message = 'Campaign name is required';                       
            } else {
                //add data
                let result = await axios.post('/api/campaign/create/' + this.campaignName.trim());
                let campaign = result.data.campaign;

                if (campaign != null) {
                  // this.refreshdata;
                  message = 'Data added.';                
                }                           
                this.$emit('hidechild',true);
                this.clear();                
            }
            
        } else {
            //update
            await axios.put('/api/campaign/update/' + this.campaignID + '/' + this.campaignName);
            this.clear();
            // this.refreshdata;
            this.$emit('hidechild',true);
            message = 'Data updated';
            
        }

        if (message != '') {            
           this.$dialog.alert(message);
        }
       dialog.close();
      
    },
    hide: function() {
      this.clear();
      this.$emit('hidechild',false);
      //this.$emit("close");
    },
    clear(){
      this.campaignID=0;
      this.campaignName='';
    },
    async remove(){
      if (this.campaignID > 0) {
        //delete
        await axios.put('/api/campaign/update/' + this.campaignID);
        // this.$parent.methods.getAllCampaigns();
        // this.refreshdata;
        this.clear();
        this.$emit("close");
        this.$toasted.show('Data deleted.', {
          position: 'top-center',
          //duration: 5000,
          action: {
              text: 'Ok',
              onClick: (e, toastObject) => {
                  toastObject.goAway(0);
              }
          }
        });
      }
    }
  }
};
</script>

<style scoped>
.formview{
  font-family: 16px;
	margin: 0 auto;
	max-width: 600px;
	width: 50%;
  background-color: lightgrey;
}
.field {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  padding: 20px 0px;
}

.field > label {
  width: 80px;
  padding-left: 20px;
  font-weight: bold;
}
.field > input[type="text"] {
  font-family: "Montserrat", sans-serif;
  width: 70%;
}
.title{
  padding-left:20px;
  padding-top: 10px;
}
    /* button */
    .button {
        background-color: cornflowerblue; 
        color: white;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        font-weight: 700;
        border-radius: 4px;
    }
    .button-darkorange{
        background-color: darkorange; 
        color: white;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        font-weight: 700;
        border-radius: 4px;
    }
    .buttonDelete {
        background-color: #ff3232;
        color: white;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        font-weight: 700;
        border-radius: 4px;
    }
</style>