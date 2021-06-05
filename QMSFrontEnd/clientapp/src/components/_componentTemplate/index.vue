<template>
    <div class="mainDiv">
        <adminnav></adminnav>
        <main>
            <router-view></router-view>
        </main>
    </div>
</template>

<script>
    import adminnav from '@/components/navigation/topnavigation.vue'
    export default {
        name: 'AdminMan',
        components: { adminnav },
        data() {
            return {
                pagename:'Index Manager'
            }
        },
        computed: {
            routes() {
                //todo: return will vary on the logged in user role
                return this.$router.options.routes.find(x => x.name == 'admin')
                    .children.filter(
                        x => x.name == 'user' || x.name == 'campaign' || x.name == 'lob'
                            || x.name == 'calltype' || x.name == 'supportassign' || x.name == 'issue'
                            || x.name == 'coaching'
                    );
            },
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .mainDiv {
        padding: 0 50px 50px 50px;
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

   
</style>
