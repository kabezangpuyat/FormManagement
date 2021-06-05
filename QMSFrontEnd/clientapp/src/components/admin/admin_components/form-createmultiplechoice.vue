<template>
<!-- <div class="modal">  -->
  <div class="formview">
    <div class="title">New Form Multiple Choice</div>
    <!-- <div class="title" v-if="this.lobID==0">New User</div>
    <div class="title" v-else>Edit LOB</div> -->
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
    <div class="fieldinner" v-if="questionTypeId==4 || questionTypeId==1 || questionTypeId==2">
      <label class="labelinner"># of Choices</label>
      <input v-model="choiceItem" type="number" class="innertext2" @keyup="setchoiceitem" @change="setchoiceitem"/>
    </div>
    <div v-if="questionTypeId==4 || questionTypeId==1 || questionTypeId==2">
      <div class="fieldinner" v-for="n in choiceItems" :key="n">
        <label class="labelinner">Choice {{n}}</label>
        <input type="text" class="innertext" placeholder="Choice" :id="'txtChoice_' + n">
        <label class="labelinner">Value {{n}}</label>
        <input type="number" class="innertext2" placeholder="Value" :id="'txtValue_' + n">
      </div>
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
        <!-- <tbody > -->
            <!-- <tr  v-if="nodata">
                <td colspan="3">No data to display</td>
            </tr> -->
            <tr v-for="data in addedData" :key="data.id">
              <td colspan="4">
                <table style="width:100%;">
                  <tr>
                    <td align="center" style="cursor:pointer;">{{data.htmlcontrolid==4 ? 'Check box' :(data.htmlcontrolid==1 ? 'Radio button' : (data.htmlcontrolid==2 ? 'Select' : 'Textbox'))}}</td>
                    <td>Multiple choice</td>
                    <td>{{data.formquestion}}</td>
                    <td>                    
                        <font-awesome-icon :icon="'trash-alt'" 
                            v-confirm="{ok: dialog => remove(data.id),
                            message:'Delete data?'}"
                            style="cursor:pointer;" />
                        <!-- <font-awesome-icon :icon="'trash'" v-else /> -->
                        &nbsp;
                        <font-awesome-icon :icon="'eye'" :id="'feye_' + data.id"
                          title="Show choices" 
                          data-toggle="tooltip" v-if="data.htmlcontrolid==4 || data.htmlcontrolid==1 || data.htmlcontrolid==2"
                          style="cursor:pointer;"
                          @click="displaychoices(true, data.id,data.htmlcontrolid)" />
                        <font-awesome-icon :icon="'eye-slash'" :id="'fslash_' + data.id"
                          title="Show choices" 
                          data-toggle="tooltip" 
                          style="cursor:pointer; display:none"
                          @click="displaychoices(false,data.id,data.htmlcontrolid)" />
                    </td>
                  </tr>
                  <tr :id="'trchoices_' + data.id" style="display:none;">
                    <td>
                      <table class="flextable" style="width:60%">
                        <thead>
                            <tr style="background-color:lightskyblue;">
                                <td style="width:90%;">Choice</td>
                                <td>Value</td>
                            </tr>
                            <tr v-for="child in data.choicedata" :key="child.id" ><td  style="width:90%;">{{child.choice}}</td><td>{{child.value}}</td></tr>
                        </thead>
                      </table>
                    </td>
                  </tr>
                </table>
              </td>

            </tr>
        <!-- </tbody> -->
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
  props: ['categoryId'],
  // components:{multiselect},
  setup(props,context){
    const catId = ref(0);
    const questiontypes = ref([]);
    const questionTypeId = ref(0);
    const choiceLabelValue = ref([]);
    const questionLabel = ref('');
    const addedData = ref([]);
    const formName = ref('');
    const choiceItems = ref([]);
    const choiceItem = ref(0);
    const showChoices = ref(false);
    const dialog = context.root.$dialog;

    const loadOnUpdate = ()=>{
      catId.value = props.categoryId;
      questiontypes.value = [{id:4,name:'Check box'},
                              {id:1,name:'Radio button'},
                              {id:2,name:'Select'},
                              {id:3,name:'Textbox'}];
      choiceItems.value = [1,2,3,4];
      choiceItem.value = 4;
      showChoices.value = false;
    }

    const addNew = ()=>{
      let message = '';

      if(formName.value.trim() == '')
        message += 'Form name is required. <br />';
      if(questionTypeId.value == 0)
        message += 'Control Type is required. <br />';
      if(questionLabel.value.trim() == '')
        message += 'Question / label is required. <br />';

      if(questionTypeId.value==4 || questionTypeId.value==1 || questionTypeId.value==2){
        if(choiceItem.value>0){
          for(var i=1;i<=choiceItem.value;i++){
            var choice = document.getElementById('txtChoice_' + i)
            var choiceValue = document.getElementById('txtValue_' + i);

            if(choice.value.trim()=='')
              message += 'Choice ' + i + ' is required. <br />';
            if(choiceValue.value.trim()=='')
              message += 'Value ' + i + ' is required. <br />';
          }
        }
      }

      
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
              let labelquestion = x.formquestion.toLowerCase() === search;
              return labelquestion;
            });
        }
          
        if(searchData.length > 0){
          dialog.alert('Question / label already exists.',{html:true});
        }else{
          //data to list
          let choicedata = [];//[{parentid:0,choice: '',value:0,sortorder:0,id:0}];
          //set up choice data
          if(questionTypeId.value==4 || questionTypeId.value==1 || questionTypeId.value==2){
            // choicedata = [];
         
            if(choiceItem.value>0){
              for(var j=1;j<=choiceItem.value;j++){
                var choice2 = document.getElementById('txtChoice_' + j)
                var choiceValue2 = document.getElementById('txtValue_' + j);
                choicedata.push({
                  id: j,
                  parentid: index,
                  choice: choice2.value.trim(),
                  value: parseInt(choiceValue2.value.trim()),
                  sortorder: j
                });
              }
            }
          }
          addedData.value.push({id: index,
                                htmlcontrolid:questionTypeId.value,
                                formquestion:questionLabel.value.trim(),
                                choicedata:choicedata});
          choicedata = [];
          choiceItem.value = 4;
          choiceItems.value = [1,2,3,4];
          questionTypeId.value = 0;
          questionLabel.value = '';
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
      addedData.value = [];
      formName.value = '';
      questionTypeId.value = 0;
      questionLabel.value = '';
      
      commonservice.redirectByName('form-admin');
    }

    const save = async () =>{
        dialog.confirm('Save data?',{loader: true})
        .then(d => {
            setTimeout(() => {
              // alert(JSON.stringify(addedData.value));
              let payload = {
                formDetail: {
                  formName: formName.value.trim(),
                  categoryId: catId.value
                },
                questionDetails: addedData.value
              };
             
              //check if question is available
              let searchData = 
                addedData.value.filter(x=>{            
                  let radiocontrol = x.htmlcontrolid === 1;//we should have radio control
                  let selectcontrol = x.htmlcontrolid === 2;
                  let checkcontrol = x.htmlcontrolid === 4;
                  return radiocontrol || selectcontrol || checkcontrol;
                });

              if(searchData.length>0){
                relogin();
                // alert(JSON.stringify(payload))
                let createformurl = commonservice.getApiHost('/api/Form/create-multiplechoice-form');
                let token = commonservice.getToken();
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                axios.post(createformurl,payload,options)
                .then((response)=>{
                  d.close();
                  // console.log(response.data.message);
                  dialog.alert(response.data.message,{html:true});
                  setTimeout(function() {
                    cancel();
                  }, 3000);	
                  
                })
                .catch(()=>{
                  d.close();
                  dialog.alert('Unexpected error encountered. Please contact your system administrator.',{html:true});
                  cancel();
                });
                // cancel();
              }else{
                d.close();
                dialog.alert('Question is required. Select check box <br /> control and create a question & choice(s).',{html:true});                
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

    const setchoiceitem = ()=>{
        if(choiceItem.value!=''){
          choiceItems.value = [];
          for(var x=1;x<=choiceItem.value;x++){
            choiceItems.value.push(x);
          }
        }
    }

    const displaychoices = (val,id,controleid)=>{
      showChoices.value = val;
      var tr = document.getElementById('trchoices_' + id);
      var eye = document.getElementById('feye_'+id);
      var slash = document.getElementById('fslash_' + id);

      if(showChoices.value){
        tr.style = '';
        eye.style = 'cursor:pointer;display:none;';
        slash.style = 'cursor:pointer;';
      }else{
        tr.style = 'display: none;';
        eye.style = 'cursor:pointer;';
        slash.style = 'cursor:pointer;display:none;';
      }
      if(controleid==3){
        eye.style = 'display:none;';
        slash.style = 'display:none;';
      }
    }

    onMounted(()=>{
      loadOnUpdate();      
		});

    return {catId,
            questiontypes,
            questionTypeId,
            questionLabel,
            choiceLabelValue,
            choiceItems,
            choiceItem,
            formName,
            addNew,
            addedData,
            remove,
            cancel,
            save,
            setchoiceitem,
            showChoices,
            displaychoices}
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