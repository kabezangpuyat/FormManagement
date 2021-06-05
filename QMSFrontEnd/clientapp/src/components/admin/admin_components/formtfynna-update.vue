<template>
<!-- <div class="modal">  -->
  <div class="formview">
    <div class="title">Update Form Data</div>
    <div class="field">
      <div class="field">
        <label>Form Name</label>
        <input type="text" v-model="formName" placeholder="Form name">
      </div>
      <label>Control Type</label>
        <select v-model="questionTypeId">
          <option disabled value="0">Please select one</option>
          <option v-for="item in questiontypes" :key="item.id" :value="item.id">{{item.name}}</option> 
        </select>
    </div>
    <div class="field">
      <label>Question / Label</label>
      <input type="text" v-model="questionLabel" placeholder="Question / Label">
      <button class="button" style="margin-right:auto;"  @click="addNew"><font-awesome-icon :icon="'plus'" /> Add</button>
    </div>
    <div class="form-buttons">
      <button class="button" v-if="addedData.length > 0 && formName.trim().length > 0" @click="save"><font-awesome-icon :icon="'save'" />&nbsp; Save</button>
      <button class="buttonCancel" @click="cancel"><font-awesome-icon :icon="'times'"/>&nbsp; Cancel</button>
    </div>

   <br />
    <table class="flex-table">
        <thead>
            <tr style="background-color:lightskyblue;">
                <td>Control Type</td>
                <td>Form Type</td>
                <td>Question / Label</td>
                <td>Actions</td>
            </tr>
        </thead>
        <tbody >
            <tr v-for="data in addedData" :key="data.id">
                <td align="center" style="cursor:pointer;">{{data.htmlControlID==1 ? 'Radio button' : 'Textbox'}}</td>
                <td>{{formtoedit.formType.name}}</td>                
                <td v-if="data.isnew==true">{{data.name}}</td>
                <td v-else><input type="text" v-model="data.name" /></td>
                <td>                    
                    <font-awesome-icon :icon="'trash-alt'"  v-if="data.isnew==true"
                        v-confirm="{ok: dialog => remove(data.id),
                        message:'Delete data?'}"
                        style="cursor:pointer;"  />
                </td>
            </tr>
            
        </tbody>
    </table>
  </div>
 
<!-- </div> -->
</template>

<script>
import axios from 'axios';
import { ref, onMounted } from '@vue/composition-api';
import commonservice from '@/services/commonservice.js';
import store from '@/store';
// import router from "@/router";
export default {
  props: ['categoryId','formtoedit'],
  // components:{multiselect},
  setup(props,context){
    const formtoedit = ref([]);
    const catId = ref(0);
    const formId = ref(0);
    const questiontypes = ref([]);
    const questionTypeId = ref(0);
    const questionLabel = ref('');
    const addedData = ref([]);
    const formName = ref('');
    const dialog = context.root.$dialog;

   const clear = () =>{
      addedData.value = [];
      formName.value = '';
      questionTypeId.value = 0;
      questionLabel.value = '';
      catId.value = 0;
      formId.value = 0;
      // formtoedit.value = [];
    }

    const loadOnUpdate = ()=>{
      clear();
      
      catId.value = props.categoryId;
      questiontypes.value = [{id:1,name:'Radio button'},
                              {id:3,name:'Textbox'}];
      formtoedit.value = props.formtoedit;
      addedData.value = formtoedit.value.questions;
      formName.value = formtoedit.value.name;
      formId.value = formtoedit.value.id;
    }

    const addNew = ()=>{
      let message = '';

      if(formName.value.trim() == '')
        message += 'Form name is required. <br />';
      if(questionTypeId.value == 0)
        message += 'Control Type is required. <br />';
      if(questionLabel.value.trim() == '')
        message += 'Question / label is required. <br />';

      if(message.trim()==''){
        //add to list
        let index = 0;
        var lastPosition = addedData.value.length -1;
        var searchData = [];
        if(addedData.value.length <= 0)
          index = 1;
        else{
          index = addedData.value[lastPosition].id + 1;
          //check if exists
          searchData = 
            addedData.value.filter(x=>{
              let search = questionLabel.value.trim().toLowerCase();              
              let labelquestion = x.name.toLowerCase() === search;
              return labelquestion;
            });
        }
          
        if(searchData.length > 0){
          dialog.alert('Question / label already exists.',{html:true});
        }else{
          //data to list
          addedData.value.push({id: index,htmlControlID:questionTypeId.value,name:questionLabel.value.trim(),isnew:true});
          questionTypeId.value = 0;
          questionLabel.value = '';
               console.log(JSON.stringify(addedData.value))
        }

      }else{
        dialog.alert(message,{html:true});
      }
    }

    const remove = (id)=>{
      for( var i = 0; i < addedData.value.length; i++){ 
        if ( addedData.value[i].id === id) { 
          addedData.value.splice(i, 1); 
          i--; 
        }
      }
    }
 
    const cancel = ()=>{
      clear();
      commonservice.redirectByName('form-admin');
    }

    const save = async () =>{
        dialog.confirm('Save data?',{loader: true})
        .then(d => {
            setTimeout(() => {
              // alert(JSON.stringify(addedData.value))
              // console.log(JSON.stringify(addedData.value))
              let payload = {
                formDetail: {
                  formName: formName.value.trim(),
                  formId: formId.value,
                  categoryId: catId.value
                },
                questionDetails: addedData.value
              };
             
              //check if question is available
              let searchData = 
                addedData.value.filter(x=>{            
                  let radiocontrol = x.htmlControlID === 1;//we should have radio control
                  return radiocontrol;
                });

              if(searchData.length>0){
                relogin();
                let createformurl = commonservice.getApiHost('/api/Form/update-basic-form');
                let token = commonservice.getToken();
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                axios.put(createformurl,payload,options)
                .then((response)=>{
                  d.close();
                  dialog.alert(response.data.message,{html:true});
                  cancel();
                })
                .catch(()=>{
                  d.close();
                  dialog.alert('Unexpected error encountered. Please contact your system administrator.',{html:true});
                  cancel();
                });
                // // cancel();
              }else{
                d.close();
                dialog.alert('Question is required. Select radio button control and <br /> create a question.',{html:true});                
              }
              
              d.close();
            }, 2500);
          });
    };

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

    onMounted(()=>{
      loadOnUpdate();      
		});

    return {catId,
            questiontypes,
            questionTypeId,
            questionLabel,
            formName,
            addNew,
            addedData,
            remove,
            cancel,
            save,
            formtoedit}
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
  padding: 5px 0px;
}

.field > label {
  width: 80px;
  padding-left: 20px;
  font-weight: bold;
  font-size:small;
}
.field > input[type="text"] {
  font-family: "Montserrat", sans-serif;
  width: 70%;
}

.fieldinner {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  padding: 5px 0px;
}

.labelinner{
  min-width: 100px;
  padding-left: 20px;
  font-weight: bold;
  font-size:small;
}
.innertext{
  font-family: "Montserrat", sans-serif;
  width: 50%;
  padding: 5px;
}
.innertext2{
  font-family: "Montserrat", sans-serif;
  width: 10%;
  padding: 5px;
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

</style>