<template>
    <router-view />
</template>
<script>
export default{
    mounted(){
        // if(this.$store.state.token==''){
        //     this.$router.push({ name: 'login' });
        // }    
    }
}
</script>

<style>
    @import url("https://fonts.googleapis.com/css?family=Montserrat");

    * {
        font-family: "Montserrat", sans-serif;
        box-sizing: border-box;
    }

    html,
    body {
        height: 100%;
        padding: 0;
        margin: 0;
    }

    #app {
        height: 100%;
        display: flex;
    }
</style>

