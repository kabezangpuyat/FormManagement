<template>
    <div id="login">
        <header>
            <img :src="require('@/assets/images/task.png')"> 
        </header>
        <input type="text" id="username" v-model="username" />
        <span class="login" @click="singIn" >
            Login with PingiD            
        </span>
    </div>
</template>

<script>
    import router from "@/router";
    import axios from 'axios';
    // import {useStore} from 'vuex';
    // import { useRouter } from 'vue-router';
    // import { reactive } from 'vue';
    import store from '@/store';
    import { ref } from '@vue/composition-api';
    import commonservice from '@/services/commonservice.js';

    export default {
        setup(_,context){
            const username = ref('1604992');
            const toasted = context.root.$toasted;

            const singIn = async ()=> {
                //TODO: ping id
                store.commit('clearData');
                store.commit('clearformtoedit');  
                
                if(username.value.trim() !== ''){
                    //get api token 
                    let authenticateUrl = commonservice.getApiHost('/api/Account/authenticate/' + username.value);
                //   alert(authenticateUrl)
                    await axios.get(authenticateUrl)
                    .then((response)=>{
                        store.commit('login',response.data);
                                            
                        if(store.state.isAuthenticated){
                            let name = response.data.initialPage;
                            router.push({ name: name });
                        }
                    })
                    .catch(()=>{
                        // alert(error.message)
                        // alert(error.response.status)
                        toasted.show('Invalid login', {
                            position: 'top-center',
                            duration: 5000
                        });
                    });

                }else{
                    toasted.show('Employee number is required.', {
                        position: 'top-center',
                        duration: 5000
                    });
                }
                
            }
            return {username,singIn}
        }
    };

</script>

<style scoped>
    #login {
        /* background-color: #0096e3; */
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        height: 100%;
    }

    header {
        color: #0096e3;
        font-weight: bold;
        font-size: 150px;
        display: flex;
        align-items: center;
        justify-content: flex-start;
        transform: translateY(-20px);
    }

    img {
        height: 150px;
        width: auto;
        margin-right: 5px;
    }

    span {
        display: inline-block;
        padding: 10px 30px;
        font-size: 24px;
        border: 1px solid white;
    }

        span.login {
            border: 1px solid #0096e3;
            background-color: #0096e3;
            color: white;
            border-radius: 50px;
            cursor: pointer;
            margin-top: 10px;
            transition-duration: 0.5s;
        }

            span.login:hover {
                background-color: white;
                color: #0096e3;
                border: 1px solid #0096e3;
            }
</style>
