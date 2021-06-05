<template>
    <div class="content" >        
        <headertitle :text="pagename"> </headertitle>
        <div class="control-bar" v-if="!showForm">
            <div style="margin-right:auto;">
                <strong>Search</strong>&nbsp;&nbsp;
                <input type="text"
                       class="custom-input"
                       placeholder="i.e. Name, Term"
                       style="min-width:150px;"
                       v-model="filters.searchText">
                &nbsp;&nbsp;
                <label><strong>Wave</strong></label>
                &nbsp;&nbsp;
                <select v-model="filters.batchfilterid">
                <option value="0">All</option>
                <option v-for="item in this.batches" :key="item.waveNumber" :value="item.waveNumber">{{item.name}}</option> 
                </select>
            </div>

        </div>
        <br />
        <table class="flex-table">
            <thead>
                <tr style="background-color:lightskyblue;">
                    <td style="width:25%;">Wave</td>
                    <td style="width:25%;">Support</td>
                    <td style="width:25%;">Employee Number</td>
                    <td style="width:25%;">Action</td>
                </tr>
            </thead>
            <tbody @scroll="scrolledToEnd">
                <tr  v-if="noData">
                    <td colspan="5">No data to display</td>
                </tr>
                <tr v-for="(data,i) in filteredList" :key="data.newID">
                    <td align="center"  style="width:25%;">Wave &nbsp; {{data.waveNumber}}</td>
                    <td v-if="data.supportFullname!=''" align="center"  style="width:25%;">{{data.supportFullname}}</td><td v-else>NA</td>
                    <td v-if="data.supportEmployeeNumber!=''" align="center"  style="width:25%;">{{data.supportEmployeeNumber}}</td><td v-else>NA</td>
                    <td align="left"  style="width:25%;">
                        <dropdown 
                            :data="selectsupport.list"
                            :rowindex="i"
                            :selectedSupport="data"
                            @getAll="getAll" 
                            @removeall="removetoarray"
                        >
                        </dropdown>    
                          <!-- <font-awesome-icon :icon="'trash-alt'" v-if="!edit" v-tooltip="'Delete'" />                       -->
                    </td>
                </tr>
            </tbody>
        </table>
        
    </div>    
</template>

<script>
    import axios from 'axios'
    import headertitle from '@/components/header.vue';
    import dropdown from '@/components/admin/controls/supportdelegationdropdown.vue';
    // import lobform from "@/components/admin/admin_components/supportassignment-form.vue";
    export default {
        name: 'SupportAssignment',
        components: { headertitle, dropdown },
        data() {
            return {
                pagename: 'Survey Form',
                batches:[],
                supports: [],
                edit:false,
                filters: {
                    searchText: '',
                    batchfilterid: 0
                },
                pagination: {
                    index: 1,
                    fetchCount: 30
                },
                selectsupport:{
                    id: 0,
                    list: []
                },
                showForm: false
            }
        },
        mounted() {
            this.getAll(true);
        },
        watch: {
            filters: {
                handler() {
                    let elem = this.$el.querySelector("tbody");
                    elem.scrollTop = 0;
                    this.pagination = {
                        index: 1,
                        fetchCount: 30
                    };
                },
                deep: true
            }
        },
        computed: {
            filteredList() {             
                let items = this.supports;
                let searchText = this.filters.searchText.trim().toLowerCase();          
                if (searchText) {
                    items = items.filter(x => {
                        let supportnamematches = x.supportFullname.toLowerCase().includes(searchText);
                        let supportEIDMatches = x.supportEmployeeNumber.toLowerCase().includes(searchText);
                        
                        return supportnamematches || supportEIDMatches;
                    });
                }

                if(this.filters.batchfilterid >0){
                    let wavenum = this.filters.batchfilterid;
                   
                    items = JSON.parse(JSON.stringify(items)).filter(function (entry) {
                        return entry.waveNumber === wavenum;
                    });
                }

                items = items.slice(
                    0,
                    this.pagination.index * this.pagination.fetchCount
                );

                return items;
            },
            noData() {
                let data = this.filteredList.length;
                let showNoData = data > 0 ? false : true;

                return showNoData;
            },
        },
        methods: {
            async getAll(isinit) {
                if(isinit){
                    let result = await axios.get('/api/employeesupport/all');
                    if(result.data.isAuthenticated == false){
                        this.$dialog.alert('Session expired!!!',{html:true});
                        this.$store.commit('clearData');
                        axios.post('/api/Authenticate/logout');
                        this.$router.push({ name: "login" });
                    }else{
                        this.batches = result.data.employeesupportmodels.batches;
                        this.supports = result.data.employeesupportmodels.supportList;
                        this.selectsupport.list = result.data.employeesupportmodels.supports;
                    }  
                }else{
                    let result = await axios.get('/api/employeesupport/refresh');
                    if(result.data.isAuthenticated == false){
                        this.$dialog.alert('Session expired!!!',{html:true});
                        this.$store.commit('clearData');
                        axios.post('/api/Authenticate/logout');
                        this.$router.push({ name: "login" });
                    }else{
                        this.supports = result.data.employeesupportmodels.supportList;
                    }  
                }
            },            
            scrolledToEnd($event) {
                let element = $event.target;
                if (element.scrollHeight - element.scrollTop === element.clientHeight) {
                    this.pagination.index++;
                }
            },
            cancel(){
                this.edit = false;
                this.selectsupport.id=0;
            },
            async removetoarray(){
                // this.supports.splice(index,1);
                this.supports = [];
                let result = await axios.get('/api/employeesupport/refresh');
                this.supports = result.data.employeesupportmodels.supportList;
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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

      /*  .flex-table tr td:nth-of-type(1) {
            max-width: 200px;
            text-align: center;
        }

        .flex-table tr td:nth-of-type(2) {
            max-width: 200px;
            text-align: center;
        }

        .flex-table tr td:nth-of-type(3) {
            max-width: 200px;
            text-align: center;
        }

         .flex-table tr td:nth-of-type(4) {
            max-width: 200px;
            text-align: center;
        } 

        .flex-table tr td:nth-of-type(5) {
            max-width: 200px;
            text-align: center;
        }*/

        .flex-table tbody tr td:nth-of-type(3) {
            /* display: flex; */
            text-align: left;
            /* justify-content: space-around; */
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
</style>
