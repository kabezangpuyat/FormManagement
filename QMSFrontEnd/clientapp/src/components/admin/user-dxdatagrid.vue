<template>
    <div class="content" >        
        <headertitle :text="pagename"> </headertitle>
        <popup v-if="showForm" @hidechild="hidechild" v-bind:data="data"></popup>
        
        <div class="control-bar">
            <button class="button" style="margin-right:auto;"  @click="addNew"><font-awesome-icon :icon="'plus'" /> Add New</button>
            <div style="margin-left:auto;">
                <button class="button" style="margin-right:auto;"  @click="getUsers"><font-awesome-icon :icon="'recycle'" /> Refresh</button>
            </div>
        </div>
        <br />
        <div class="dxdiv">
            <DxDataGrid
                :data-source="dataSource"
                :show-borders="true"
                :selection="{ mode: 'single' }"
                :hover-state-enabled="true"
                key-expr="id"
                @selection-changed="onSelectionChanged"
                @exporting="onExporting"
            >
                <DxExport :enabled="true"/>
                <DxPaging :page-size="5"
                    :page-index="0"
                    :showNavigationButtons="true"
                />
                <DxPager
                    :show-page-size-selector="true"
                    :allowed-page-sizes="pageSizes"
                    :show-info="true"
                />
                <DxSearchPanel :visible="true" />
                <DxFilterRow :visible="true" />

                <DxColumn data-field="username" caption="Employee Number" :allowFiltering="false"/>
                <DxColumn data-field="email" :allowFiltering="false"/>
                <DxColumn data-field="firstName" :allowFiltering="false"/>
                <DxColumn data-field="lastName" :allowFiltering="false"/>
                <DxColumn data-field="active" :allowFiltering="false"/>
            </DxDataGrid>            
        </div>
<br />
        <table class="flex-table">
            <thead>
                <tr style="background-color:lightskyblue;">
                    <td>Employee Number</td>
                    <td>Email</td>
                    <td>First Name</td>
                    <td>Last Name</td>
                </tr>
            </thead>
            <tbody @scroll="scrolledToEnd">
                <tr  v-if="noData">
                    <td colspan="3">No data to display</td>
                </tr>
                <tr v-for="data in filteredList" :key="data.id">
                    <td align="center" @click="showDataToEdit(data)" style="cursor:pointer;">{{data.name}}</td>
                    <td>{{data.status}}</td>
                    <td>{{data.dateCreated}}</td>
                    <td>
                        <font-awesome-icon :icon="'edit'" @click="showDataToEdit(data)" 
                            style="cursor:pointer;" 
                             />&nbsp;                        
                        <font-awesome-icon :icon="'trash-alt'" 
                            v-confirm="{ok: dialog => remove(dialog,data.id),
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
    import { ref, onMounted } from '@vue/composition-api';
    import commonservice from '@/services/commonservice.js';
    import popup from "@/components/admin/admin_components/user-form.vue";
    import store from '@/store';
    import { DxDataGrid, DxColumn, DxPager, DxPaging , DxFilterRow, DxSearchPanel,DxExport} from 'devextreme-vue/data-grid';
    //for exporting datagrid
    import { exportDataGrid } from 'devextreme/excel_exporter';
    import { Workbook } from 'exceljs';
    import saveAs from 'file-saver';
    
    export default{
        name: 'User Management',
        components: { 
            popup,
            headertitle,
            DxDataGrid,
            DxColumn,
            DxPager,
            DxPaging,
            DxFilterRow,
            DxSearchPanel,
            DxExport
        },
        setup(){
            const pagename = ref('User Management');
            const dataSource = ref([]);
            const pageSizes = ref([5, 10, 20]);
            const data = ref({});
            const showForm = ref(false);

            const getUsers = async ()=>{
                let isvalidToken = await axios.get(commonservice.validateTokenUrl());
                let isValid = isvalidToken.data.valid;
                
                if(!isValid){
                    relogin();
                }
                let token = commonservice.getToken();
                //get users 
                let getuserurl = commonservice.getApiHost('/api/User/get-all');
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                let getUsers = await axios.get(getuserurl,options);
                dataSource.value = getUsers.data.results;
                // alert(JSON.stringify(users.value))
            }

            const onSelectionChanged = ({ selectedRowsData })=>{
                data.value = selectedRowsData[0];
                showForm.value=true;
            }
            const onExporting = (e)=>{
                const workbook = new Workbook();
                const worksheet = workbook.addWorksheet('UserList');
                exportDataGrid({
                    component: e.component,
                    worksheet: worksheet,
                    customizeCell: function(options) {
                        const excelCell = options;
                        excelCell.font = { name: 'Arial', size: 12 };
                        excelCell.alignment = { horizontal: 'left' };
                    } 
                }).then(function() {
                    workbook.xlsx.writeBuffer()
                        .then(function(buffer) {
                            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'UserList.xlsx');
                        });
                });
                e.cancel = true;
            }
            
            const relogin = async ()=>{
                let authmodel = {
                    "username": commonservice.getEmployeeNumber(),
                    "password": "******"
                };
                let authenticateUrl = commonservice.getApiHost('/api/Account/authenticate');
                let result = await axios.post(authenticateUrl, authmodel);
                store.commit('clearData');
                store.commit('login',result.data);
            }

            const addNew = ()=>{
                data.value = [];
                showForm.value=true;
            }
         
            const hidechild = (refershdata)=>{
                alert('hidechild')
                showForm.value=false;
                // data={};
                if(refershdata==true){                    
                    getUsers();
                }
                alert((data.value==[]))
                if(!(data.value==[])){
                    alert('ssss')
                    onSelectionChanged(null);
                    getUsers();
                }
            }
      
            onMounted(()=>{
				getUsers();
			});
            return {pagename, 
                    dataSource, 
                    getUsers, 
                    pageSizes,
                    onSelectionChanged,
                    onExporting,
                    addNew,hidechild,
                    data,
                    showForm}
        }
    }
    // export default {
    //     name: 'LOBManagement',
    //     components: { headertitle,lobform },
    //     data() {
    //         return {
    //             pagename: 'User',
    //             lobs: [],
    //             lob:{},
    //             filters: {
    //                 searchText: ''
    //             },
    //             pagination: {
    //                 index: 1,
    //                 fetchCount: 30
    //             },
    //             showForm: false
    //         }
    //     },
    //     mounted() {
    //         this.getAllLOBs();
    //     },
    //     watch: {
    //         filters: {
    //             handler() {
    //                 let elem = this.$el.querySelector("tbody");
    //                 elem.scrollTop = 0;
    //                 this.pagination = {
    //                     index: 1,
    //                     fetchCount: 30
    //                 };
    //             },
    //             deep: true
    //         }
    //     },
    //     computed: {
    //         filteredList() {             
    //             let items = this.lobs;
    //             let searchText = this.filters.searchText.trim().toLowerCase();
                              
    //             if (searchText) {
    //                 items = items.filter(x => {
    //                     let matches = x.name.toLowerCase().includes(searchText);

    //                     return matches;
    //                 });
    //             }

    //             items = items.slice(
    //                 0,
    //                 this.pagination.index * this.pagination.fetchCount
    //             );

    //             return items;
    //         },
    //         noData() {
    //             let data = this.filteredList.length;
    //             let showNoData = data > 0 ? false : true;

    //             return showNoData;
    //         },
    //     },
    //     methods: {
    //         async getAllLOBs() {
    //             let result = await axios.get('/api/lob/all');
    //             this.lobs = result.data.lobs;
    //             //alert(JSON.stringify(result.data.lobs))
    //         },            
    //         scrolledToEnd($event) {
    //             let element = $event.target;
    //             if (element.scrollHeight - element.scrollTop === element.clientHeight) {
    //                 this.pagination.index++;
    //             }
    //         },
    //         showDataToEdit(lob) {
    //             this.showForm=true;
    //             this.lob=lob;
    //         },
    //         addNew(){
    //             this.showForm=true;
    //             // this.$modal.show(lobform, null, {
    //             //     height: "auto",
    //             //     pivotY: 0.1
    //             // });
    //             this.lob={};
    //         },
    //         hidechild(refershdata){
    //             this.showForm=false;
    //             this.lob={};
    //             if(refershdata==true){                    
    //                 this.getAllLOBs();
    //             }
    //         },
    //         async remove(dialog,id){
    //             if(id>0){
    //                 await axios.put('/api/lob/update/' + id);
    //                 this.getAllLOBs();
    //                 //this.$dialog.alert('Data deleted.');
    //                 dialog.close();
    //             }
    //         }
    //     }
    // }
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
