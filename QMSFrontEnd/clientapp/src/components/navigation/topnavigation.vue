<template>
    <div class="topnav">
        <!--<router-link v-for="route in routes"
                 active-class="active"
                 :key="route.displayname"
                 :to="route.path">{{route.displayname}}</router-link>-->
        <router-link active-class="active" to="/admin/usermanagement">User</router-link>
        <router-link active-class="active" to="/admin/campaignmanagement">Campaign</router-link>
        <router-link active-class="active" to="/admin/lobmanagement">LOB</router-link>
        <router-link active-class="active" to="/admin/calltypemanagement">Call Type</router-link>
        <router-link active-class="active" to="/admin/supportassignment">Support Assignment</router-link>
        <router-link active-class="active" to="/admin/issuemanagement">Issue</router-link>
        <router-link active-class="active" to="/admin/coachingoppmanagement">Coaching Opportunity</router-link>

    </div>
</template>

<script>
    export default {
        //TODO: Make the route dynamically rendered from route.js

    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    /* TOP NAVIGATION */
    .topnav {
        overflow: hidden;
        background-color: #333;
    }

        .topnav a {
            float: left;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
            font-size: 17px;
        }

            .topnav a:hover {
                background-color: #ddd;
                color: black;
            }

            .topnav a.active {
                background-color: cadetblue;
                color: white;
            }

</style>
