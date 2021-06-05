<template>
    <div class="modal">
    <div class="formview">
        <div class="title">Issue</div>
         <!--<div class="field">
            <label>LOB</label>
            <select v-model="lobid">
                <option disabled value="0">Please select one</option>
                <option v-for="item in lobs" :key="item.id" :value="item.id">{{item.name}}</option>  
            </select>
        </div>-->
        <div class="field">
            <label>Subject</label>
             <input type="text" v-model="subject">
        </div>
        <div class="form-buttons">
            <button class="button" @click="save">Save</button>
            <button class="button" @click="hide">Cancel</button>
            <button class="buttonDelete" v-if="this.lobid>0" @click="remove">Delete</button>
        </div>
    </div>    
        
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'IssueMangement',
        data() {
            return {
                pagename: 'Issue Manager',
                lobid:0,
                subject:"",
                issueID:0,
                lobs:[]
            }
        },
        mounted(){
             //alert(JSON.stringify(this.data));
            if(Object.keys(this.data).length == 0){
                //this.clear();
            }else{
                this.subject=this.data.subject;
                this.lobid=this.data.lobid;
                this.issueID=this.data.id;
                
            } 
            //alert(this.data.subject);
            this.getAllLOBs();
        },
        props: ['data'],
        methods: {
            hide: function () {
                //this.clear();
                this.$emit('hidechild',false);
            },
            
            async save () {
                //alert(this.issueID);
                if(this.issueID==0 || this.issueID===undefined){
                    //add new
                    let result = await axios.post('/api/issue/create/' + this.lobid+'/'+ this.subject.trim());
                    let issue = result.data.issue;
                    if(issue != null){
                        alert("Successfully saved.");
                        this.$emit('hidechild',true);
                
                    }else{
                        alert("Fail.");
                        this.$emit('hidechild',true);
                
                    }
                }else{
                    //update
                    await axios.put('/api/issue/update/' + this.issueID + '/' + this.subject.trim());
                    this.$emit('hidechild',true);

                }
                
                
            },
            async remove(){
                if (this.issueID > 0) {
                    //delete
                    await axios.put('/api/issue/update/' + this.issueID);
                    // this.$parent.methods.getAllCampaigns();
                    // this.refreshdata;
                    //this.clear();
                    this.$emit('hidechild',true);
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
            },
            async getAllLOBs() {
                let result = await axios.get('/api/lob/all');
                this.lobs = result.data.lobs;
               // alert(JSON.stringify(this.lobs))
            }, 


        }
    }
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
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }
</style>
