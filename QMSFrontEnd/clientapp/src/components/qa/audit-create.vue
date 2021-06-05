<template>
<div class="content" >        
    <headertitle :text="pagename" style="display:none;"> </headertitle>
    <div class="control-bar" style="height:40px;">
        <div style="margin-left:auto;">
            <button class="buttonrefresh" style="margin-right:auto;" @click="save"  v-if="form.name!=undefined"><font-awesome-icon :icon="'save'" /> Save</button>
            &nbsp;
            <button class="button-darkorange" style="margin-right:0;" @click="cancel"><font-awesome-icon :icon="'window-close'" />&nbsp;Cancel</button>
        </div>
    </div>
    <br />
    <div class="formview">
        <div class="field">
            <label>Form(s)</label>
            <select v-model="formId" style="height:27px; font-size:small;width:50%;"  @change="change(formId)">
                <option disabled value="0">Please select one</option>
                <option v-for="item in dataSource" :key="item.id" :value="item.id">{{item.name}}</option>
            </select>
        </div> 
        <div class="field">
            <label>Audit Title</label>
            <input type="text" v-model="auditTitle" style="height:25px; font-size:small;width:50%;" placeholder="Audit Title">
        </div>
        <div class="field">
            <label>Teammate(s)</label>
            <select v-model="userId" style="height:27px; font-size:small;width:50%;">
                <option disabled value="0">Please select one</option>
                <option v-for="item in users" :key="item.id" :value="item.id">{{item.username + ' - ' + item.lastName + ', ' + item.firstName}}</option> 
            </select>
        </div>
        <div class="field">
            <label>Note</label>
            <textarea v-model="note" style="width:50%;height:100px;"></textarea>
        </div>
    </div>
    <br />
    <!-- <div class="mainDiv" v-if="form.name==undefined"> -->
    <div class="mainDiv" v-if="form.name!=undefined">
        <div class="divForm">
            <div class="divFormHeader">{{form.name}}</div>
            <div id="divItems" class="divItems" v-for="question in form.questions" :key="question.id">
                <!-- {{question}} -->
                <strong>{{question.name}}</strong> &nbsp;
                <br />
                <div v-if="question.htmlControlID==1 || question.htmlControlID==4">
                    <div v-for="(v,index) in question.choices" :key="index">
                        <!-- 1 = option; 2 = dropdown; 3: textbox; 4: checkbox -->
                        <!--DISPLAY RADIO BUTTON-->
                        <input v-if="question.htmlControlID==1" 
                            type="radio" 
                            :id="question.id + '_' + v.id" 
                            :value="v.id" 
                            :name="'radio_' + question.id" >
                        <label :for="question.id + '_' + v.id" v-if="question.htmlControlID==1"> {{v.name}}</label>

                        <!-- DISPLAY CHECKBOX -->
                        <input type="checkbox" :id="'chk_' + v.id" :name="'chk_' + v.id" :value="v.id" v-if="question.htmlControlID==4">
                        <label :for="'chk_'+ v.id"  v-if="question.htmlControlID==4"> {{v.name}}</label><br>                   

                    </div>
                </div>
                <input type="text" class="txt" v-if="question.htmlControlID==3" :id="'txtQuestion_'+question.id" />               
                <!-- DISPLAY DROPDOWN  -->
                <select style="width:300px; font-size: 10px;" 
                    v-if="question.htmlControlID==2"
                    :name="'ddl_'+question.id"
                    :id="'ddl_'+question.id"
                    >
                    <option disabled value="0" selected>[SELECT]</option>
                    <option v-for="c in question.choices" :key="c.id" :value="c.id">{{c.name}}</option>
                </select>
            </div>
        </div>
    </div>
    <br />
    <br />
</div>    
</template>

<script>
    import axios from 'axios';
    import headertitle from "@/components/header.vue";
    import { ref, onMounted } from '@vue/composition-api';
    import commonservice from '@/services/commonservice.js';
    import store from '@/store';
    // import router from "@/router";
    
    export default{
        name: 'Audit Create',
        components: { 
            headertitle,
        },
        setup(_,context){
            const pagename = ref('Create Audit');
            const dataSource = ref([]);  
            const users = ref([]);
            const form = ref({});  
            const formId = ref(0);
            const userId = ref(0);
            const auditTitle = ref('');
            const note = ref('');
            const dialog = context.root.$dialog;

            const getallforms = async ()=>{
                relogin();
                let token = commonservice.getToken();
                //get  
                let formurl = commonservice.getApiHost('/api/Form/get-all-by-logged-user');
                           
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                let getall = await axios.get(formurl,options);
               
                dataSource.value = getall.data.forms;
            }

            const getAllUsers = async ()=>{
                relogin();
                let token = commonservice.getToken();
                //get  
                let formurl = commonservice.getApiHost('/api/User/get-all-tm-by-logged-user-campaign');
                           
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                let getall = await axios.get(formurl,options);
                users.value = getall.data.results;
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
                  
            const cancel = ()=>{
                commonservice.redirectByName('audit-qa');
            }

            const change = (id)=>{
                let item = dataSource.value.find( x => x.id === id);
                form.value = item;
            }

            const save = async ()=>{
                let message = '';

                let questions = form.value.questions;
                let auditDetails = [];

                if(auditTitle.value.trim()=='')
                    message += 'Audit title is required. <br />';
                if(userId.value==0)
                    message += 'Please select teammate. <br />';

                for(var i = 0; i < questions.length; i++) {
                    var question = questions[i];

                    //validate textbox
                    if(question.htmlControlID==3){
                        //textbox
                        var txt = document.getElementById('txtQuestion_' + question.id);
                        if(txt.value.trim()==''){
                            message += '[' + question.name + '] is required. <br />';
                        }else{
                            //insert to auditdetails
                            let detail = {
                                questionID: question.id,
                                choiceID: 0,
                                questionNotes: txt.value.trim()
                            };
                            auditDetails.push(detail);
                        }                            
                    }

                    //validate radio button and checkbox
                    if(question.htmlControlID==1 || question.htmlControlID==4){
                        var numofchecedradio = 0;
                        for(var j=0;j<question.choices.length;j++){
                            var choice = question.choices[j];
                            var rad = document.getElementById(question.id + '_' + choice.id );
                            if(question.htmlControlID==4)
                                rad = document.getElementById('chk_' + choice.id );

                            if(rad.checked){
                                numofchecedradio = 1;
                                let detail = {
                                    questionID: question.id,
                                    choiceID: choice.id,
                                    questionNotes: choice.name
                                };
                                auditDetails.push(detail);

                                if(question.htmlControlID==1)
                                    break;
                            }
                        }
                        if(numofchecedradio==0){
                            message += '[' + question.name + '] is required. <br />';
                        }
                        //var rad = document.getElementById(question.id + '_' );
                    }

                    //validate dropdown
                    if(question.htmlControlID==2){
                        var ddl = document.getElementById('ddl_' + question.id);
                        var selected = ddl.value;
                        var text= ddl.options[ddl.selectedIndex].text;
                        if(selected==0){
                            message += '[' + question.name + '] is required. <br />';
                        }else{
                            let detail = {
                                questionID: question.id,
                                choiceID: parseInt(selected),
                                questionNotes: text
                            };
                            auditDetails.push(detail);
                        }
                    }
                }

                if(message.trim()!='')
                    dialog.alert(message,{html:true});
                else{
                    //todo: call insert here
                    var payload = {
                        formID:formId.value,
                        auditName:auditTitle.value.trim(),
                        formNotes: note.value,
                        userID:parseInt(userId.value),
                        auditDetails:auditDetails
                    };
                    //************************************* */
                    dialog.confirm('Save data?',{loader: true})
                    .then(d => {
                        setTimeout(() => {
                            relogin();
                            let url = commonservice.getApiHost('/api/Audit/create');
                            let token = commonservice.getToken();
                            let options={
                                headers:{'Authorization' : `bearer ${token}`}
                            };
                            axios.post(url,payload,options)
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
                        
                          d.close();
                        }, 3000);
                    });

                    console.log(payload)
                }
            }

            onMounted(()=>{
                // setTimeout(function() {
                    getallforms(); 
                    getAllUsers();
                // }, 3000);				         
			});

            return {pagename, 
                    getallforms, 
                    cancel,
                    formId,
                    dataSource,
                    change,
                    form,
                    save,
                    users,
                    userId,
                    auditTitle,
                    note
                    }
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
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
.title{
  padding-left:20px;
  padding-top: 10px;
}
    /* .dx-datagrid-headers{
        background-color: cadetblue;
    } */
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }

  
    /* button */
    .button {
            background-color: dodgerblue; 
            color: white;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            font-weight: 700;
            border-radius: 4px;
    }
    .buttonrefresh {
            background-color: rgb(4, 139, 76); 
            color: white;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            font-weight: 700;
            border-radius: 4px;
            min-width: none;
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
    .mainDiv {
        padding: 0px 50px 100% 50px; /* change padding */
        overflow: scroll;
        width: 100%;
        height: 100%;
        position: fixed;
    }
    .divForm{        
        background-color: #fff;
        border-style: solid;
        border-color: rgb(37, 36, 36);
        border-radius: 1mm;
        max-width: 96%;
        font-size: small;
    }
    .divFormHeader{
        padding: 4px 2px 4px 7px;
        color: white;
        font-weight: bold;
        background-color: #06436b;
        border-bottom-style: solid;
    }
    .divItems{
        padding: 10px 5px 10px 5px;
        font-size: small;
        /* position: relative; */
    }
    .txt{
        width: 800px;
        font-size: 14px;
    }
</style>
