<template>
    <div class="content" >        
        <headertitle :text="pagename"> </headertitle>
        <lobform  v-if="showForm" @hidechild="hidechild" v-bind:data="this.lob"></lobform>
        
        <div class="control-bar">
            <button class="button" @click="addNew" style="margin-right:auto;"><font-awesome-icon :icon="'plus'" /> Add New</button>
            <div style="margin-left:auto;">
                <strong>Search</strong>&nbsp;&nbsp;
                <input type="text"
                       class="custom-input"
                       placeholder="i.e. Name, Term"
                       style="min-width:150px;"
                       v-model="filters.searchText">
            </div>
        </div>
        <br />
        <table class="flex-table">
            <thead>
                <tr style="background-color:lightskyblue;">
                    <td>Name</td>
                    <td>Status</td>
                    <td>Date Created</td>
                    <td>Action</td>
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
    import axios from 'axios'
    import headertitle from "@/components/header.vue";
    import lobform from "@/components/admin/admin_components/user-form.vue";
    export default {
        name: 'Form Create/Update',
        components: { headertitle,lobform },
        data() {
            return {
                pagename: 'Form Create/Update',
                lobs: [],
                lob:{},
                filters: {
                    searchText: ''
                },
                pagination: {
                    index: 1,
                    fetchCount: 30
                },
                showForm: false
            }
        },
        mounted() {
            this.getAllLOBs();
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
                let items = this.lobs;
                let searchText = this.filters.searchText.trim().toLowerCase();
                              
                if (searchText) {
                    items = items.filter(x => {
                        let matches = x.name.toLowerCase().includes(searchText);

                        return matches;
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
            async getAllLOBs() {
                let result = await axios.get('/api/lob/all');
                this.lobs = result.data.lobs;
                //alert(JSON.stringify(result.data.lobs))
            },            
            scrolledToEnd($event) {
                let element = $event.target;
                if (element.scrollHeight - element.scrollTop === element.clientHeight) {
                    this.pagination.index++;
                }
            },
            showDataToEdit(lob) {
                this.showForm=true;
                this.lob=lob;
            },
            addNew(){
                this.showForm=true;
                // this.$modal.show(lobform, null, {
                //     height: "auto",
                //     pivotY: 0.1
                // });
                this.lob={};
            },
            hidechild(refershdata){
                this.showForm=false;
                this.lob={};
                if(refershdata==true){                    
                    this.getAllLOBs();
                }
            },
            async remove(dialog,id){
                if(id>0){
                    await axios.put('/api/lob/update/' + id);
                    this.getAllLOBs();
                    //this.$dialog.alert('Data deleted.');
                    dialog.close();
                }
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
