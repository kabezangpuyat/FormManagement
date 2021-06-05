<template>
<div class="modal"> 
  <div class="formview">
    <div class="title" >{{currentUserId==0 ? 'New User' : 'Update User'}}</div>
    <!-- <div class="title" v-if="this.lobID==0">New User</div>
    <div class="title" v-else>Edit LOB</div> -->
    <div class="field">
      <label>Role</label>
        <select v-model="roleid">
          <option disabled value="0">Please select one</option>
          <option v-for="item in roles" :key="item.id" :value="item.id">{{item.name}}</option> 
        </select>
    </div>
    <div class="field">
      <label>Campaign</label>
        <select v-model="campaignid" multiple style="width:350px;height:100px;">
          <option disabled value="0">Please select one</option>
          <option v-for="item in campaigns" :key="item.id" :value="item.id">{{item.name}}</option> 
        </select>
    </div>
    <div class="field">
      <label>Employee Number</label>
      <input type="text" v-model="employeenumber" placeholder="Employee Number">
    </div>
    <div class="field">
      <label>Email</label>
      <input type="text" v-model="email" placeholder="Email">
    </div>
    <div class="field">
      <label>First Name</label>
      <input type="text" v-model="fn" placeholder="First Name">
    </div>
    <div class="field">
      <label>Last Name</label>
      <input type="text" v-model="ln" placeholder="Last Name">
    </div>
    <div class="form-buttons">
      <button class="button" 
            @click="save"><font-awesome-icon :icon="'save'"/>&nbsp; Save</button>
        <button class="buttonCancel" @click="hide"><font-awesome-icon :icon="'times'"/>&nbsp; Cancel</button>
    </div>
  </div>
</div>
</template>

<script>
import axios from 'axios';
import { ref, onMounted } from '@vue/composition-api';
import commonservice from '@/services/commonservice.js';
import store from '@/store';
export default {
  props: ['data'],
  // components:{multiselect},
  setup(props,context){
    const currentUserId = ref(0);
    const campaigns = ref([]);
    const roles = ref([]);
    const roleid = ref(0);
    const campaignid = ref([]);
    const employeenumber = ref('');
    const email = ref('');
    const fn = ref('');
    const ln = ref('');
    const dialog = context.root.$dialog;

    const getAllRoles = async ()=>{
        roles.value = await getAllData('/api/Role/get-all');
    }
    const getAllCampaigns = async ()=>{
        campaigns.value = await getAllData('/api/Campaign/get-all');
    }

    const getAllData = async (endpoint)=>{
        relogin();
        let token = commonservice.getToken();
        //get users 
        let url = commonservice.getApiHost(endpoint);
        let options={
            headers:{'Authorization' : `bearer ${token}`}
        };
        let allData = await axios.get(url,options);
        return allData.data.results;
    }
    const createOrUpdate = async(endpoint,payload,isupdate)=>{
        relogin();
        let token = commonservice.getToken();
        //get users 
        let url = commonservice.getApiHost(endpoint);
        let options={
            headers:{'Authorization' : `bearer ${token}`}
        };
        if(isupdate){
          let result = await axios.put(url,payload,options);
          return result.data;  
        }else{
          let result = await axios.post(url,payload,options);
          return result.data;  
        }
      
    }

    const hide = ()=> {
      clear();
      context.emit('hidechild',false);
    }

    const relogin = async ()=>{
        let isvalidToken = await axios.get(commonservice.validateTokenUrl());
        let isValid = isvalidToken.data.valid;

        if(!isValid){          
          let authenticateUrl = commonservice.getApiHost('/api/Account/authenticate/' + commonservice.getEmployeeNumber());
          let result = await axios.get(authenticateUrl);
          store.commit('clearData');
          store.commit('login',result.data);
        }
    }

   const save = async ()=> {
     
      var message = '';
      if(roleid.value==0)
        message += 'Role is required. <br />';
      if(campaignid.value.length==0)
        message += 'Campaign is required. <br />';
      if(employeenumber.value=='')
        message += 'Employee number is required. <br />';
      if(email.value=='')
        message += 'Email is required. <br />';
      if(fn.value=='')
        message += 'First name is required. <br />';
      if(ln.value=='')
        message += 'Last name is required. <br />';

      if(message.trim()!=''){
        dialog.alert(message,{html:true});
      }else{
        dialog.confirm('Save data?',{loader: true})
        .then(d => {
            setTimeout(() => {
              if(Object.keys(props.data).length > 0){
                //edit
                  let payload = {
                    'id': props.data.id,
                    'username': employeenumber.value,
                    'email': email.value,
                    'firstName': fn.value,
                    'lastName': ln.value,
                    'middleName': '',
                    'roleId': roleid.value,
                    'campaignIds': campaignid.value
                  }
                  
                  createOrUpdate('/api/User/update',payload,true)
                  .catch((e)=>{
                    console.log(e);
                    dialog.alert('Unexpected error occured. <br /> Please contact your system admistrator.',{html:true});
                    d.close();
                  })
                  .then((value)=>{
                    console.log(JSON.stringify(value));
                    d.close();
                    dialog.alert('Data updated.',{html:true});
                    clear();
                    context.emit('hidechild',true);
                  });
              }else{
                  let payload = {
                    'username': employeenumber.value,
                    'email': email.value,
                    'firstName': fn.value,
                    'lastName': ln.value,
                    'middleName': '',
                    'roleId': roleid.value,
                    'campaignIds': campaignid.value
                  }
                  createOrUpdate('/api/User/create',payload,false)
                  .catch((e)=>{
                    console.log(e);
                    dialog.alert('Unexpected error occured. <br /> Please contact your system admistrator.',{html:true});
                    d.close();
                  })
                  .then((value)=>{
                    console.log(JSON.stringify(value));
                    d.close();
                    dialog.alert('Data created.',{html:true});
                    clear();
                    context.emit('hidechild',true);
                  });
              }
            }, 2500);
          });
        // .catch(() => {
        //   dialog.alert('Canceled!!!',{html:true});
        // });
      }
      
    }

    const clear = ()=>{
      roleid.value = 0;
      campaignid.value = [];
      employeenumber.value = '';
      email.value = '';
      fn.value = '';
      ln.value = '';
    }

    const loadOnUpdate = ()=>{
      if(Object.keys(props.data).length > 0){
        if(props.data.roles.length > 0){
          roleid.value = props.data.roles[0].id;
        }        
        let campaignids = [];
        let campaignlist = props.data.campaigns;
        for (var i in campaignlist) {
          campaignids.push(campaignlist[i].id);
        }
        campaignid.value = campaignids;
        employeenumber.value = props.data.username;
        email.value = props.data.email;
        fn.value = props.data.firstName;
        ln.value = props.data.lastName;
        currentUserId.value = props.data.id;
      }
    }

    onMounted(()=>{
      loadOnUpdate();      
			getAllRoles();
      getAllCampaigns();
		});

    return {campaigns,
            roles,
            hide,
            roleid,
            campaignid,
            save,
            employeenumber,
            email,
            fn, 
            ln,
            currentUserId}
  },
  
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