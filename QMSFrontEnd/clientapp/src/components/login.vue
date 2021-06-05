<template>
    <div id="login">
        <header>
            <img :src="require('@/assets/images/task.png')"> 
        </header>
        <span class="login" @click="singIn" v-if="!isLoggingIn" >
            Login with PingiD            
        </span>
        <span v-else-if="isLoggingIn && !isFailed">
            <font-awesome-icon :icon="['fas','spinner']" spin />
            {{message}}
        </span>
    </div>
</template>

<script>
    import axios from 'axios';
    import commonservice from '@/services/commonservice.js';
    import { ref, onMounted } from '@vue/composition-api';
     export default {
        setup(_,context){
            const isLoggingIn = ref(false);
            const isFailed = ref(false);
            const message = ref('');
            const toasted = context.root.$toasted;

            const singIn = async ()=> {
                isLoggingIn.value = true;
                commonservice.redirecttoping();          
            }

            const authenticate = async ()=>{
                commonservice.clearData();
                const code = commonservice.getUrlParamValue('code');

                if(code!=null){
                    isLoggingIn.value = true;
                    isFailed.value = false;

                    console.log(`code:${code}`);
                    let authenticateUrl = commonservice.getApiHost('/api/Account/authenticate-ping/' + code);
                    
                    await axios.get(authenticateUrl)
                    .then((response)=>{
                        commonservice.storeLoginData(response);

                        if(commonservice.isAuthenticated()){   
                            let name = response.data.initialPage;
                            // router.push({ name: name });             
                            commonservice.redirectByName(name);
                        }
                    })
                    .catch((error)=>{
                        console.log(error);
                        toasted.show('Invalid login', {
                            position: 'top-center',
                            duration: 5000
                        });
                    });
                    
                    // let result = await axios.post(authenticateUrl,ping);
                    // commonservice.storeLoginData(result);
                    
                    // if(commonservice.isAuthenticated()){   
                    //     let name = result.data.initialPage;
                    //     // router.push({ name: name });             
                    //     commonservice.redirectByName(name);
                    // }
                }
            }
            onMounted(()=>{
                authenticate();
            })
            return {singIn, isLoggingIn, isFailed, message}
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
