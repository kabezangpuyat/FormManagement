<template>
    <div class="content" >        
        <headertitle :text="pagename"> </headertitle>
        <popup v-if="showForm" @hidechild="hidechild" v-bind:data="data"></popup>
        
        <div class="control-bar">
            <button class="button" style="margin-right:auto;"  @click="addNew"><font-awesome-icon :icon="'plus'" /> Add New</button>
            
            <div style="margin-left:auto;">
                <strong>Search</strong>&nbsp;&nbsp;
                <input type="text"
                       class="custom-input"
                       placeholder="i.e. Name, Term"
                       style="min-width:150px;"
                       v-model="searchtext">
                &nbsp;
                <button class="buttonrefresh" style="margin-right:0;" @click="getForms"><font-awesome-icon :icon="'sync'" />&nbsp;refresh</button>
            </div>
        </div>
<br />
    
            <table class="flex-table">
                <thead>
                    <tr style="background-color:lightskyblue;">
                        <td>Form Name</td>
                        <td>Form Type</td>
                        <td>Category</td>
                        <td>Actions</td>
                    </tr>
                </thead>
                <tbody @scroll="scrolledToEnd" style="scroll">
                    <tr  v-if="nodata">
                        <td colspan="3">No data to display</td>
                    </tr>
                    <tr v-for="data in filteredList" :key="data.id">
                        <td align="center" @click="onedit(data)" style="cursor:pointer;">{{data.name}}</td>
                        <td>{{data.formType.name}}</td>
                        <td>{{data.category.name}}</td>
                        <td>
                            <font-awesome-icon :icon="'edit'" @click="onedit(data)" 
                                style="cursor:pointer;" 
                                />&nbsp;                        
                            <font-awesome-icon :icon="'trash-alt'" 
                                v-confirm="{ok: dialog => remove(data.id),
                                message:'Delete data?'}"
                                style="cursor:pointer;" v-if="!showForm" />
                            <font-awesome-icon :icon="'trash'" v-else />
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
        name: 'Form Management',
        components: { 
            popup,
            headertitle,
        },
        setup(_,context){
            const dialog = context.root.$dialog;
            const pagename = ref('Form Management');
            const dataSource = ref([]);    // lobs[]
            const pageSizes = ref([5, 10, 20]);
            const data = ref({}); // lob
            const showForm = ref(false);     
            const pagination = ref({
                        index: 1,
                        fetchCount: 13
                    });//pagination
            const searchtext = ref(''); // filters
            
            const getForms = async ()=>{
                relogin();
                let token = commonservice.getToken();
                //get users 
                let getuserurl = commonservice.getallformurl();
                           
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                let getForms = await axios.get(getuserurl,options);
                dataSource.value = getForms.data.forms;
            }

            const remove = async (id)=>{
                if(id>0){
                    relogin();
                    let token = commonservice.getToken();
                    //get users 
                    let url = commonservice.getApiHost('/api/Form/update-form-status');
                    let config={
                        headers:{'Authorization' : `bearer ${token}`}
                    };
                    let payload={
                        "id": id,
                        "active": false
                    };
                    
                    await axios.put(url,payload,config)
                    .then((response)=>{
                        dialog.alert(response.data.message,{html:true});
                        getForms();
                    })
                    .catch((error)=>{
                        console.log(error);
                        console.log(token)
                        dialog.alert('Unexpected error encountered.',{html:true});
                    });
                }
            }

            const onedit = (content)=>{               
                store.commit('clearformtoedit');                
                data.value = content;
                store.commit('setformtoedit',content);
                router.push({ name: 'form-update' });
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
                    getForms();
                }              
            }

            const filteredList = computed(()=>{
                let items = dataSource.value;
                let searchText = searchtext.value.trim().toLowerCase();
                              
                if (searchText) {
                    items = items.filter(x => {
                        let usernames = x.username.toLowerCase().includes(searchText);
                        let emails = x.email.toLowerCase().includes(searchText);
                        let fns = x.firstName.toLowerCase().includes(searchText);
                        let lns = x.lastName.toLowerCase().includes(searchText);

                        return usernames || emails || fns || lns;
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
                    getForms(); 
                // }, 3000);				         
			});

            return {pagename, 
                    dataSource, 
                    getForms, 
                    pageSizes,
                    addNew,hidechild,
                    data,
                    showForm,
                    nodata,
                    onedit,
                    scrolledToEnd,
                    pagination,
                    searchtext,
                    filteredList,
                    remove
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
