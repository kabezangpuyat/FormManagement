<template>
<div class="modal"> 
  <div class="formview">
    <div class="title" v-if="this.lobID==0">New User</div>
    <div class="title" v-else>Edit LOB</div>
    <div class="field">
      <label>Campaign</label>
        <select v-model="campaignID">
          <option disabled value="0">Please select one</option>
          <option v-for="item in campaigns" :key="item.id" :value="item.id">{{item.name}}</option> 
        </select>
    </div>
    <div class="field">
      <label>Name</label>
      <input type="text" v-model="lobName" placeholder="LOB Name">
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
 
  mounted() {
     if(Object.keys(this.data).length == 0){
      this.clear();
    }else{
      this.campaignID=this.data.campaignID;
      this.campaignName=this.data.campaignName;
      this.lobID=this.data.id;
      this.lobName=this.data.name;    
    }   
    this.getAllCampaigns();
  },
  props: ['data'],
  data() {
    return {
      campaignName:'',
      lobName:'',
      campaignID: 0,
      lobID:0,
      selected:0,
      campaigns:[]
    };
  },
  methods: {
    async getAllCampaigns() {
      let result = await axios.get('/api/campaign/all');
      this.campaigns = result.data.campaigns;
    }, 
    async save() {
      var message = '';
        if (this.lobID == 0 || this.lobID === undefined) {
          if(this.campaignID==0){
            message += 'Campaign is required <br />';   
          }
          if (this.lobName.trim() == '') {
                message += 'Lob name is required <br />';  
          }
          if(message=='') {
              //add data
              // let result = 
              await axios.post('/api/lob/create/' + this.lobName.trim() + '/' + this.campaignID);
              //let lob = result.data.lob;
                           
              this.$emit('hidechild',true);
              this.clear();
          }
            
        } else {
            //update
          if (this.lobName.trim() == '') {
            message += 'Lob name is required <br />';  
          }else{
            await axios.put('/api/lob/update/' + this.lobID + '/' + this.lobName + '/' + this.campaignID);
            this.clear();
            message='';
            this.$emit('hidechild',true);
          }
        }

        if (message != '') {            
            this.$dialog.alert(message,{html:true});
        }
        // this.getAllCampaigns();
      this.$emit('close');
    },
    hide: function() {
      this.clear();
      this.$emit('hidechild',false);
    },
    clear(){
      this.campaignID=0;
      this.campaignName='';
      this.lobName='';
      this.lobID=0;
    },
    async remove(){
      if (this.lobID > 0) {
        //delete
        await axios.put('/api/lob/update/' + this.lobID);
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