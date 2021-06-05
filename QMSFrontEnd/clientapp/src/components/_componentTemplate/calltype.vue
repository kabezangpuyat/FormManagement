<template>
    <div class="content">
        <headertitle :text="pagename"></headertitle>
        <div class="control-bar">
            
            <button class="button" @click="addCallType" style="margin-right:auto;">
                <font-awesome-icon :icon="'plus'" /> Add New</button>
            
            <div style="margin-left:auto;">
                Search&nbsp;&nbsp;
                <input type="text"
                class="custom-input"
                placeholder="i.e. description, date"
                style="min-width:150px;"
                v-model="filters.searchText"
                :keyup="test">
            </div>

        </div>
        <br />
        <table class="flex-table">
            <thead>
                <tr style="background-color:lightskyblue;">
                    <td align="left">Description</td>
                    <td>Date Created</td>
                    <td>Action</td>
                </tr>
            </thead>
            <tbody @scroll="scrolledToEnd" >
                <tr  v-if="noData">
                    <td colspan="3">No data to display</td>
                </tr>
                <tr v-for="calltype in filteredList" :key="calltype.id">
                    <td>{{calltype.description}}</td>
                    <td>{{calltype.dateCreated}}</td>
                    <td>
                        <font-awesome-icon :icon="'file'" @click="viewcalltypelob(calltype)"/>&nbsp; |
                        <font-awesome-icon :icon="'edit'" @click="editCallType(calltype)"/>&nbsp; |
                        <font-awesome-icon :icon="'trash-alt'" @click="remove(calltype)"/>
                    </td>
                    <td style='display:none;'>{{calltype.name}}</td>
                </tr>
            </tbody>
        </table>
    <v-dialog />
    </div>
</template>

<script>
import headertitle from "../header.vue";
import newcalltype from './admin_components/calltype_forms/calltype-new.vue';
import viewcalltypelob from "./admin_components/calltype_forms/calltype-view.vue";
    // import edit from './admin_components/calltype-edit.vue';

    export default {
        components: {headertitle},
        mounted() {
            this.$store.dispatch('calltype/getAll');
            this.getCallType();
        },
        name: 'CallTypeManagement',
        data() {
            return {
                pagename: 'Case Type',
                callType: [],
                callTypeId: 0,
                filters: {
                    searchText: ''
                },
                pagination: {
                    index: 1,
                    fetchCount: 30
                },
                selected: {
                    callTypeId: 0
                },
            }
        },
        methods: {
            test() {
                alert('test');
            },
            getCallType() {
                this.callType = this.$store.getters['calltype/getAll'];
            },
            scrolledToEnd($event) {
                let element = $event.target;
                if (element.scrollHeight - element.scrollTop === element.clientHeight) {
                    this.pagination.index++;
                }
            },
            addCallType() {
                this.$modal.show(newcalltype, null, {
                    height: "auto",
                    pivotY: 0.1
                });
            },
            viewcalltypelob(data) {
                this.$modal.show(
                    viewcalltypelob, 
                    {
                        existingCallType: data
                    },
                    {
                        height: "auto",
                        width: 800,
                        pivotY: 0.1
                    }
                );
            },
            editCallType(data) {
                this.$modal.show(
                    newcalltype, 
                    {
                        isEdit: true,
                        existingCallType: data
                    },
                    {
                        height: "auto",
                        width: 600,
                        pivotY: 0.1
                    }
                );
            },
            remove: function(data) { 
                let ctx = this;
                this.$modal.show("dialog", {
                    title: "Confirm Action",
                    text: `Are you sure you want to delete "${data.description}"?`,
                    buttons: [
                    {
                        title: "Yes",
                        handler: async function() {
                        await ctx.$store.dispatch("calltype/delete", { id: data.id });
                        ctx.$modal.hide("dialog");
                        }
                    },
                    {
                        title: "No",
                        handler: async function() {
                        ctx.$modal.hide("dialog");
                        }
                    }
                    ]
                });
            },
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
                let items = this.callType;
                let searchText = this.filters.searchText.trim().toLowerCase();
                              
                if (searchText) {
                    items = items.filter(x => {
                        let matches = x.description.toLowerCase().includes(searchText);
                        let matchesname = x.name.toLowerCase().index(searchText);
                        return matches || matchesname;
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
            }
        }
    }
</script>


<style scoped>
.flex-table {
  height: calc(100% - 100px);
}
.flex-table tr td:nth-of-type(2) {
  max-width: 150px;
  text-align: center;
}
.flex-table tr td:nth-of-type(3) {
  max-width: 100px;
  text-align: center;
}

.flex-table tbody tr td:nth-of-type(2) {
  display: flex;
  justify-content: space-evenly;
  align-items: center;
}

.flex-table tr td:nth-of-type(2) > * {
  transition-duration: 0.5s;
  cursor: pointer;
  color: rgba(0, 0, 0, 0.75);
  margin: 5px;
}
.flex-table tbody tr td:nth-of-type(3) {
  display: flex;
  justify-content: space-around;
}

table tr td:nth-of-type(2) > *:hover {
  transform: scale(1.1);
}

table input {
  border: none;
  font-size: 14px;
  background-color: transparent;
  outline: none;
  width: 100%;
}

#NewCallType{
  font-size: 14px;
  outline: none;
  width: 200px;
  padding: 6px;
  border: 1px solid rgba(0, 0, 0, 0.3);
  border-radius: 5px;
}

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
</style>
