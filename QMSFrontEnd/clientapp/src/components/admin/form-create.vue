<template>
    <div class="content mainDiv" >        
        <headertitle :text="pagename"> </headertitle>
        <div class="control-bar">
            <div style="margin-right:auto;">
                <strong>Form Category</strong>&nbsp;&nbsp;
                <select id="ddlCategories" v-model="categoryId" style="width:250px;" >
                    <option disabled value="0">Please select one</option>
                    <option v-for="item in categories" :key="item.id" :value="item.id">{{item.name}}</option> 
                </select>
            </div>
        </div>
        <br />
        <div>
            <formcreateyesno id="frmYN" v-if="categoryId==1" v-bind:categoryId="categoryId"></formcreateyesno>  
            <formcreatetruefalse id="frmTF" v-if="categoryId==2" v-bind:categoryId="categoryId"></formcreatetruefalse>     
            <formna id="frmNA" v-if="categoryId==3" v-bind:categoryId="categoryId"></formna>   
            <formmultiselect id="frmMultiselect" v-if="categoryId==4"  v-bind:categoryId="categoryId"></formmultiselect>
        </div>
    </div>    
</template>

<script>
    import axios from 'axios';
    import headertitle from "@/components/header.vue";
    import { ref, onMounted } from '@vue/composition-api';
    import commonservice from '@/services/commonservice.js';
    import formcreatetruefalse from "@/components/admin/admin_components/form-create-truefalse.vue";
    import formcreateyesno from "@/components/admin/admin_components/form-create-yesno.vue";
    import formna from "@/components/admin/admin_components/form-na.vue"
    import formmultiselect from '@/components/admin/admin_components/form-createmultiplechoice.vue';
    import store from '@/store';
    // import router from "@/router";
    
    export default{
        name: 'Form Create',
        components: { 
            formcreatetruefalse,
            formcreateyesno,
            formna,
            formmultiselect,
            headertitle,
        },
        setup(){
            // const dialog = context.root.$dialog;
            const pagename = ref('Form Create');
            const categories = ref([]);
            const categoryId = ref(0);

            const getAllActiveFormCategories = async ()=>{
                relogin();
                let token = commonservice.getToken();
                //get all active categories 
                let getallactivecaturl = commonservice.getApiHost('/api/FormCategory/get-all-by-status?active=true');
                let options={
                    headers:{'Authorization' : `bearer ${token}`}
                };
                let getAllCategories = await axios.get(getallactivecaturl,options);
                categories.value = getAllCategories.data.formCategories;
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

            onMounted(()=>{
				getAllActiveFormCategories();          
			});

            return {pagename, 
                    categories,
                    categoryId
                    }
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.mainDiv {
    /* padding: 0px 50px 20px 50px; */
    overflow: scroll;
    height: 100%;
    position: relative;
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
