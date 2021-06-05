<template>
    <div class="content">
        <headertitle :text="pagename"> </headertitle>
        <issueForm  v-if="showForm" @hidechild="hidechild" v-bind:data="this.issue"></issueForm>
            
            <div class="control-bar">
                <button @click="addIssue" style="margin-right:auto;" class="button">
                    <font-awesome-icon :icon="'plus'" /> Add New
                </button>
            
                 <div style="margin-left:auto;">
                    <strong>Search</strong>&nbsp;&nbsp;
                    <input type="text"
                        class="custom-input"
                        placeholder="i.e. Name, Term"
                        style="min-width:150px;"
                        v-model="filters.searchText">
                </div>

                
                <!--<storeselect @selection-changed="onChanged" :storeName="'campaigns'" :defaultToFirst="'true'" />&nbsp;&nbsp;-->
                <!--<button @click="addCampaign">
                  <font-awesome-icon :icon="'plus'"/>&nbsp;New
                </button>
                <button @click="editCampaign">
                  <font-awesome-icon :icon="'edit'"/>&nbsp;Edit
                </button>
                <button @click="deleteCampaign">
                  <font-awesome-icon :icon="'trash'"/>&nbsp;Delete
                </button>-->
                
            </div>

            <table class="flex-table">
                <thead>
                    <tr style="background-color:lightskyblue;">
                        
                        <td>Subject</td>
                        <td>DateCreated</td>
                        <td>Action</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="issue in filteredList" :key="issue.ID">
                     
                        <td @click="showDataToEdit(issue)" style="cursor:pointer;">{{issue.subject}}</td>
                        <td>{{issue.dateCreated}}</td>
                        <td>
                            <font-awesome-icon :icon="'edit'" @click="showDataToEdit(issue)" 
                                style="cursor:pointer;" 
                                />&nbsp;                        
                            <font-awesome-icon :icon="'trash-alt'" 
                                v-confirm="{ok: dialog => remove(dialog,issue.id),
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
    import issueForm from "./admin_components/issue-form.vue";

    export default {
        name: 'IssueMangement',
        components: { headertitle,issueForm },
        data() {
            return {
                pagename: 'Struggling With',
                issues:[],
                showForm: false,
                issue:{},
                filters:{
                    searchText: ''
                },
                pagination: {
                    index: 1,
                    fetchCount: 30
                }
            }
        },
         mounted() {
             
            this.getAllIssues();
        },watch: {
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
                let items = this.issues;
                let searchText = this.filters.searchText.trim().toLowerCase();
                              
                if (searchText) {
                    items = items.filter(x => {
                        let matches = x.subject.toLowerCase().includes(searchText);

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
                let issues = this.filteredList.length;
                let showNoData = issues > 0 ? false : true;

                return showNoData;
            },
        },
        methods: {
            addIssue() {
               
                this.showForm=true;
                this.issue={};
            },
            showDataToEdit(issue) {
                this.showForm=true;
                this.issue=issue;
            },
            hidechild(refershdata){
                this.showForm=false;
                this.lob={};
                if(refershdata==true){                    
                    this.getAllIssues();
                }

            },
            async getAllIssues(){
                let result = await axios.post('/api/issue/all');
                this.issues = result.data.issues;
                //alert(JSON.stringify(this.issues))
            },
            async remove(dialog,id){
                if(id>0){
                    await axios.put('/api/issue/update/' + id);
                    this.getAllIssues();
                    //this.$dialog.alert('Data deleted.');
                    dialog.close();
                }
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .mainDiv {
        padding: 50px 50px 50px 50px;
    }

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

    .flex-table tr td:nth-of-type(3) {
        max-width: 100px;
        text-align: center;
    }

    .flex-table tr td:nth-of-type(2) {
        max-width: 250px;
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
