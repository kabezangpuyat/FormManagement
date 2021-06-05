<template>
    <div class="content mainDiv" >        
        <headertitle :text="pagename"> </headertitle>
        <div class="control-bar">
            <div style="margin-right:auto;">
                <strong>{{form.category.name}}</strong>&nbsp;&nbsp;
            </div>
        </div>
        <br />
        <div>
            <formtfynnaupdate id="frmYN" v-if="categoryId != 4" 
                v-bind:formtoedit="form"
                v-bind:categoryId="categoryId"></formtfynnaupdate>  
            <formmultiplechoiceupdate id="frmMultiplechoice" v-if="categoryId == 4"
                v-bind:formtoedit="form"
                v-bind:categoryId="categoryId"
            ></formmultiplechoiceupdate>
        </div>
    </div>    
</template>

<script>
    // import axios from 'axios';
    import headertitle from '@/components/header.vue';
    import { ref, onMounted } from '@vue/composition-api';
    // import commonservice from '@/services/commonservice.js';
    import formtfynnaupdate from '@/components/admin/admin_components/formtfynna-update.vue';
    import formmultiplechoiceupdate from '@/components/admin/admin_components/form-updatemultiplechoice.vue'
    import store from '@/store';
    // import router from "@/router";
    
    export default{
        name: 'Form Update',
        components: { 
            formtfynnaupdate,
            formmultiplechoiceupdate,
            headertitle,
        },
        setup(){
            // const dialog = context.root.$dialog;
            const pagename = ref('Form Update');
            const form = ref({});
            const categoryId = ref(0);

            const initialize = ()=>{
                let data = store.getters.getformtoedit;                
                form.value = data;
                categoryId.value = data.category.id;
            }

            onMounted(()=>{
                initialize();
			});

            return {pagename, 
                    form,
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
