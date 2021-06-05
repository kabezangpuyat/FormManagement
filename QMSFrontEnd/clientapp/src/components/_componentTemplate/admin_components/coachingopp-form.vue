<template>
<div class="modal">
  <div class="formview">
    <div class="title" v-if="this.id==0 || this.id===undefined">New Coaching Opportunity</div>
    <div class="title" v-else>Edit Coaching Opportunity</div>
    <div class="field">
      <label>All Lob of {{this.lobCampaign}}</label>
        <input type="checkbox"  :checked="this.allLobs" @click="checked(allLobs)" />
    </div>
    <div class="field" v-if="!this.allLobs">
      <label>LOB</label>
        <select style="width:400px;" v-model="multipleselect.lobids" multiple> 
          <option v-for="item in multipleselect.lobs" :key="item.id" :value="item.id" >{{item.name}}</option> 
        </select>
    </div>
    <div class="note" v-if="!this.allLobs">NOTE: Hold 'ctr' key then select lob(s)</div>
    <div class="field">
      <label>Name</label>
      <input type="text" v-model="name" placeholder="Input Name">
    </div>
    <div class="form-buttons">
        <button class="button" 
            v-confirm="{ok: dialog => save(dialog),
                        message:'Save data?'}"><font-awesome-icon :icon="'save'"/>&nbsp; Save</button>
        <button class="buttonCancel" @click="hide"><font-awesome-icon :icon="'times'"/>&nbsp; Cancel</button>
    </div>
  </div>
</div>
</template>

<script>
import axios from 'axios';
export default {
  props:['data','loblist'],
  mounted() {
   if(Object.keys(this.data).length == 0){
      this.id=0;
      this.name='';
      this.multipleselect.lobids=[];
    }else{
      this.id=this.data.id;
      this.name=this.data.name;  
      if(this.data.lobViewModels!=null){
        if(Object.keys(this.data.lobViewModels).length>0){
          for(var i=0;i<Object.keys(this.data.lobViewModels).length;i++){
            this.multipleselect.lobids.push(this.data.lobViewModels[i]['id']);          
          }
        } 
      }
  
    }

    if(Object.keys(this.loblist).length == 0){
      this.multipleselect.lobs=[];
      // this.multipleselect.lobids=[];
      this.lobCampaign = '';
    }else{
      this.multipleselect.lobs=this.loblist;      
      // this.multipleselect.lobids=[];    
      this.lobCampaign = this.loblist[0]['campaignName'];
    }
  },  
  data() {
    return {
      name:'',
      id: 0,
      lobCampaign:'',
      allLobs:false,
      multipleselect:{
        lobs:[],
        lobids:[],
        all:0
      }
    };
  },
  methods: {
    async save(dialog) {
      var message = '';
      var selectedlobs = Object.keys(this.multipleselect.lobids).length;
      if(this.allLobs==false)
        if(selectedlobs==0)
          message += 'Please select Lob(s) <br />';
      
      if(this.name=='')
        message += 'Name is required. <br />';

      if (this.id == 0 || this.id === undefined) {
        if(message == ''){
          let data = {
            name: this.name,
            isAllCampaign: this.allLobs,
            lobids: this.multipleselect.lobids
          };
          let result = await axios.post('/api/coachingopportunity/create',data);
          
          if(result.data.message===''){
            this.$emit('hidechild',true);
            this.clear(); 
          }else{
            message = result.data.message;
          }          
        }          
      } else {
        if(message == ''){
          let data = {
            name: this.name,
            isAllCampaign: this.allLobs,
            lobids: this.multipleselect.lobids,
            coachingOpportunityID:this.id
          };
          let result = await axios.put('/api/coachingopportunity/update',data);
          
          if(result.data.message===''){
            this.$emit('hidechild',true);
            this.clear(); 
          }else{
            message = result.data.message;
          }          
        }
      }

      if (message != '') {            
          this.$dialog.alert(message,{html:true});
      }
      dialog.close();
      
    },
    hide: function() {
      this.clear();
      this.$emit('hidechild',false);
    },
    clear(){
      this.id=0;
      this.name='';
    },
    async remove(){
      if (this.id > 0) {
        //delete
        await axios.put('/api/campaign/update/' + this.id);
        this.clear();
        this.$emit("close");
      }
    },
    checked(ischecked){
      if(ischecked)
        this.allLobs = false;
      else
        this.allLobs = true;
    }
  }
};
</script>

<style scoped>
.formview{
  background-color: #fefefe;
  margin: auto;
  padding: 20px;
  border: 1px solid #888;
  width: 80%;
  /* font-family: 16px;
	margin: 0 auto;
	max-width: 600px;
	width: 50%;
  background-color: lightgrey; */
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
.note{
  padding-left:20px;
  font-size: 11px;
}
    /* button */
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
    .buttonCancel{
        background-color: rgb(226, 235, 229); 
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

.modal {
  display: ''; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 100px; /* Location of the box */
  padding-left: 400px;
  padding-right: 300px;
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.4); /* Black w/ opacity */}

</style>