<template>  
<div>
      <font-awesome-icon :icon="'reply'" 
        style="cursor:pointer;" v-tooltip="'Cancel'" v-if="edit"
        @click="cancel" /> &nbsp;
      <font-awesome-icon :icon="'save'"  v-tooltip="'Save'"
        style="cursor:pointer;" 
        v-confirm="{ok: dialog => delegate(dialog,support),
        message:'Delegate new support?'}"
        v-if="edit" />&nbsp;                 

      <select v-model="selectsupport.selected" v-if="this.edit">
          <option disabled value="0">Delegate Support</option>
          <option v-for="item in this.data" :key="item.id" :value="item.id">{{item.fullname}}</option> 
      </select>
      &nbsp;
      <font-awesome-icon :icon="'edit'" @click="showeditfields" 
                                style="cursor:pointer;" 
                                v-if="!edit" v-tooltip="'Edit'" />

      <font-awesome-icon :icon="'trash-alt'" 
        v-confirm="{ok: dialog => remove(dialog,support),
        message:'Delete data?'}"
        style="cursor:pointer;" v-if="!edit" v-tooltip="'Delete'" />&nbsp;  
</div>
</template>

<script>
import axios from 'axios';
export default {
 
  mounted() {
    this.support = {};
    if(Object.keys(this.data).length == 0){
      this.selectsupport.list=[];
      this.selectsupport.selected=0;
    }else{
      this.selectsupport.list=this.data; 
      this.selectsupport.selected=0;
      this.selectsupport.id=0;
      this.index = this.rowindex;
      // alert(JSON.stringify(this.selectsupport.list));
    }   
    if(Object.keys(this.selectedSupport).length==0){
      this.support = {};
      // alert('null')
    }else{
      this.support = this.selectedSupport;
      // alert('not null')
    }
  },
  props: ['data','rowindex','selectedSupport'],
  data() {
    return {
      index:-1,
      edit:false,
      support:{},
      selectsupport:{
        selected:0,
        list:[],
        id:0
      }
    };
  },
  methods: {
    showeditfields(){
      this.edit=true;
    },
  async delegate(dialog,support){
      let newsupportid = this.selectsupport.selected;
      let supportID = support.supportID;
      let waveNumber = support.waveNumber;
     
      // alert('new support : ' + newsupportid)
      // alert('support : ' + supportID)
      // alert('wave : ' + waveNumber)
      if(newsupportid==0){
            this.$dialog.alert('Please select new support.',
            {
                html:true,
            });
      }else{
            let result = await axios.put(`/api/employeesupport/${supportID}/delegate/${newsupportid}/${waveNumber}`);
            if(result.data.success == false){
                this.$dialog.alert('Unexpected error encounterd. <br /> Please contact your system administrator.',
                {
                    html:true,
                });
            }
            this.cancel();
            this.$emit('getAll',false);                
            dialog.close();  
      }
    },
    async remove(dialog,supportToRemove){
        let id = supportToRemove.supportID;
        let waveNumber = supportToRemove.waveNumber;
       
        if(id>0){
            let result = await axios.put(`/api/employeesupport/${id}/delete/${waveNumber}`);
          
            if(result.data.success == false){
                this.$dialog.alert('Unexpected error encounterd. <br /> Please contact your system administrator.',
                {
                    html:true,
                });
            }
            
            this.cancel();
            this.$emit('getAll',false);  
             
            dialog.close();            
        }       
    },
    cancel(){
        this.edit = false;
        this.selectsupport.id=0;
        this.selectsupport.selected=0;
        this.index = -1
        this.support = {};
        this.$emit('getAll',false);  
    }
  }
};
</script>

<style scoped>
</style>