<template>
    <div class="content" >        
        <headertitle :text="pagename"> </headertitle>
        <popup v-if="showForm" @hidechild="hidechild" v-bind:data="data"></popup>
        
        <div class="control-bar">
            <button class="button" style="margin-right:auto;display:none;"  @click="addNew"><font-awesome-icon :icon="'plus'" /> Add New</button>
            
            <div style="margin-left:auto;">
                <strong>Search</strong>&nbsp;&nbsp;
                <input type="text"
                       class="custom-input"
                       placeholder="i.e. Name, Term"
                       style="min-width:150px;"
                       v-model="searchtext">
                &nbsp;
                <button class="buttonrefresh" style="margin-right:0;" @click="getAudit"><font-awesome-icon :icon="'sync'" />&nbsp;refresh</button>
            </div>
        </div>
<br />
    
            <table class="flex-table">
                <thead>
                    <tr style="background-color:lightskyblue;">
                        <td>Audit Name</td>
                        <td>Form</td>
                        <td>Audited by</td>
                        <td>Date</td>
                        <td>Action(s)</td>
                    </tr>
                </thead>
                <tbody @scroll="scrolledToEnd" style="scroll">
                    <tr  v-if="nodata">
                        <td colspan="3">No data to display</td>
                    </tr>
                    <tr v-for="data in filteredList" :key="data.id">
                        <td align="center" @click="onview(data)" style="cursor:pointer;">{{data.name}}</td>
                        <td>{{data.form.name}}</td>
                        <td>{{data.auditedBy.lastName + ', ' + data.auditedBy.firstName}}</td>
                        <td>{{data.dateCreated}}</td>
                        <td>
                            <font-awesome-icon :icon="'eye'" @click="onview(data)" 
                                title="Show Details" 
                                data-toggle="tooltip"
                                style="cursor:pointer;" 
                            />
                        </td>
                    </tr>
                </tbody>
            </table>
        
        
    </div>    
</template>

<script>
    import axios from 'axios';
    import headertitle from "@/components/header.vue";
    import { ref, onMounted, computed } from '@vue/composition-api';
    import commonservice from '@/services/commonservice.js';
    import popup from "@/components/admin/admin_components/user-form.vue";
    import store from '@/store';
    import router from "@/router";
    
    export default{
        name: 'Audit',
        components: { 
            popup,
            headertitle,
        },
        setup(){
            const pagename = ref('Audit');
            const dataSource = ref([]);    // lobs[]
            const pageSizes = ref([5, 10, 20]);
            const data = ref({}); // lob
            const showForm = ref(false);     
            const pagination = ref({
                        index: 1,
                        fetchCount: 13
                    });//pagination
            const searchtext = ref(''); // filters
            
            const getAudit = async ()=>{
                relogin();
                let token = commonservice.getToken();
                //get audit 
                let auditurl = commonservice.getApiHost('/api/Audit/get-all-by-status?active=true');
                           
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                let getAudit = await axios.get(auditurl,options);
                dataSource.value = getAudit.data.audits;
            }

            const onview = (content)=>{               
                store.commit('clearaudittoview');                
                data.value = content;
                store.commit('setaudittoview',content);
                router.push({ name: 'audit-details-view' });
            }
           
            const scrolledToEnd = ($event)=> {                             
                let element = $event.target;
                if (element.scrollHeight - element.scrollTop === element.clientHeight) {
                    pagination.value.index++;
                }
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
            
            const addNew = ()=>{
                router.push({ name: 'form-create' });
            }
         
            const hidechild = (refershdata)=>{
                showForm.value=false;
                if(refershdata==true){                    
                    getAudit();
                }              
            }

            const filteredList = computed(()=>{
                let items = dataSource.value;
                let searchText = searchtext.value.trim().toLowerCase();
                              //alert(JSON.stringify(items))
                if (searchText) {
                    items = items.filter(x => {
                        let name = x.name.toLowerCase().includes(searchText);
                        let formname = x.form.name.toLowerCase().includes(searchText);
                        let notes = x.notes.toLowerCase().includes(searchText);

                        return name || formname || notes;
                    });
                }
                // return items;
                items = items.slice(
                    0,
                    pagination.value.index * pagination.value.fetchCount
                );

                return items;
            });
            const nodata = computed(()=>{
                let data = filteredList.value.length;
                let showNoData = data > 0 ? false : true;

                return showNoData;
            });
      
            onMounted(()=>{
                // setTimeout(function() {
                    getAudit(); 
                // }, 3000);				         
			});

            return {pagename, 
                    dataSource, 
                    getAudit, 
                    pageSizes,
                    addNew,hidechild,
                    data,
                    showForm,
                    nodata,
                    onview,
                    scrolledToEnd,
                    pagination,
                    searchtext,
                    filteredList
                    }
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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

    /*  table CSS */
    .flex-table {
        height: calc(100% - 100px);
        padding-left:1cm;
        padding-right: 1cm;
    }

        .flex-table tr td:nth-of-type(1) {
            max-width: 200px;
            text-align: center;
        }

        .flex-table tr td:nth-of-type(2) {
            max-width: 200px;
            text-align: center;
        }

        .flex-table tr td:nth-of-type(3) {
            max-width: 500px;
            text-align: center;
        }

        .flex-table tr td:nth-of-type(4) {
            max-width: 200px;
            text-align: center;
        }

        .flex-table tr td:nth-of-type(5) {
            max-width: 200px;
            text-align: center;
        }

        .flex-table tbody tr td:nth-of-type(3) {
            display: flex;
            justify-content: space-around;
        }
    .dxdiv{
        padding-left:1cm;
        padding-right: 1cm;
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
</style>
