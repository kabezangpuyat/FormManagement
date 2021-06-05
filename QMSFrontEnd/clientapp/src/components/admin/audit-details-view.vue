<template>
    <div class="content mainDiv" >        
        <headertitle :text="pagename"> </headertitle>
        <div class="control-bar" style="display:none;">
            &nbsp;
        </div>
        <br />
        <div>
<!------------------------------------------------------------------------------->
          <div class="formview">
              <div class="title">Audit View</div>
              <!-- <div class="title" v-if="this.lobID==0">New User</div>
              <div class="title" v-else>Edit LOB</div> -->
              <div class="field">
                <div class="field">
                  <label>Audit Name</label>
                  <input type="text" style="width:400px;" readonly v-model="auditdata.name">
                </div>
              </div>
              <div class="field">
                <div class="field">
                  <label>Audited by</label>
                  <input type="text" style="width:400px;" readonly :value="auditdata.auditedBy.lastName + ', ' + auditdata.auditedBy.firstName">
                </div>
              </div>
              <div class="field">
                <div class="field">
                  <label>Teammate</label>
                  <input type="text" style="width:400px;" readonly :value="auditdata.teammate.lastName + ', ' + auditdata.teammate.firstName">
                </div>
              </div>
              <div class="field">
                <div class="field">
                  <label>Form</label>
                  <input type="text" style="width:400px;" readonly v-model="auditdata.form.name">
                </div>
              </div>
              <div class="field">
                <div class="field">
                  <label>Notes</label>
                  <textarea readonly style="width:400px;height:200px;" v-model="auditdata.notes"></textarea>
                </div>
              </div>
              <div class="form-audit-buttons">
                <button class="button" @click="cancel" ><font-awesome-icon :icon="'backward'"/>&nbsp; Back</button>
              </div>

            <br />
              <table class="flex-table">
                  <thead>
                      <tr style="background-color:lightskyblue;">
                          <td>Question(s) / Label(s)</td>
                          <td>Answer(s) / Comment (s)</td>
                      </tr>
                  </thead>
                  <tbody >
                      <tr v-for="audit in auditdata.details" :key="audit.id">
                          <td align="center" style="cursor:pointer;">{{audit.question.name}}</td>
                          <td align="center" style="cursor:pointer;" v-if="audit.question.htmlControl.id==3">
                            {{audit.notes}}
                          </td>
                          <td align="center" style="cursor:pointer;" v-else>
                            {{audit.choice.name}}
                          </td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
<!------------------------------------------------------------------------------->
        </div>
    </div>    
</template>


<script>
import { ref, onMounted } from '@vue/composition-api';
// import commonservice from '@/services/commonservice.js';
import store from '@/store';
import router from '@/router';
export default {
  setup(){
    const pagename = ref('Audit View');
    const auditdata = ref({});
    // const loggedRoleId = ref(store.state.roles[0].id);

    const loadaudit = ()=>{
      auditdata.value = store.state.audittoview;
    }

    const cancel = ()=>{
      auditdata.value = {};
      router.go(-1);
      // if(loggedRoleId.value==1){
      //   commonservice.redirectByName('report-admin');
      // }else if(loggedRoleId.value==2){
      //   commonservice.redirectByName('audit-qa');
      // }
      
    }

    onMounted(()=>{
      loadaudit();      
		});

    return {cancel,auditdata,pagename}
  },
  
};
</script>

<style scoped>
.mainDiv {
    /* padding: 0px 50px 20px 50px; */
    overflow: scroll;
    height: 100%;
    position: relative;
}
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
  padding: 2px 0px;
}

.field > label {
  width: 80px;
  padding-left: 20px;
  font-weight: bold;
  font-size: 13px;
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
    .form-audit-buttons {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        padding-left: 10px;
    }
        .form-audit-buttons > button {
            border: none;
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            height: 30px;
            font-size: 14px;
            padding: 0px 10px;
            user-select: none;
            margin: 5px;
            min-width: 100px;
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

    .buttonCancel{
        background-color: rgb(226, 235, 229); 
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        font-weight: 700;
        border-radius: 4px;
        justify-content: flex-start;
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