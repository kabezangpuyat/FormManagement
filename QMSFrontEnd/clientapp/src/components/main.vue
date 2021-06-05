<template>
    <div id="app">
        <customnav></customnav>
        <main>
            <router-view></router-view>
        </main>
        <!--<modals-container />-->

    </div>
</template>

<script>
    import customnav from '@/components/navigation/navbar.vue';
    import commonservice from '@/services/commonservice.js';
    // import { onMounted } from '@vue/composition-api';

    export default {
        setup(_,context){
            const route = context.root.$route;
            const toasted = context.root.$toasted;
            
            if (!commonservice.isAuthenticated()) {
                toasted.show('Unauthorized user. Please login.', {
                    position: 'top-center',
                    duration: 5000
                });
                commonservice.redirectByName('login');
            }else{
                //routename in url
                let routename = route.name;
                let appNavigations = commonservice.getAppNavigations();//navigation from DB
                let isAuthorized = appNavigations.some(function(el) {
                    return el.name === routename;
                });

                if (!isAuthorized) {
                    //clear all state and session and logout
                    commonservice.clearData();
                    toasted.show('You are not allowed to visit this url.', {
                        position: 'top-center',
                        duration: 5000
                    });
                    commonservice.redirectByName('login');
                }
            }

            return {}
        },
        components: {customnav}
    };
</script>

<style>
    #app {
        display: flex;
    }

    main {
        width: 100%;
        position: relative;
        overflow: hidden;
    }

    .content {
        height: 100%;
    }

    .modal-form {
        padding: 20px;
        height: auto;
    }

    .modal-form-lob {
        padding: 20px;
        height: 400px;
    }

    .control-bar {
        display: flex;
        align-items: center;
        background-color: rgba(128, 128, 128, 0.1);
        padding: 10px;
        height: 60px;
        margin: auto;
        width: calc(100% - 0px);
    }

        .control-bar > * {
            font-size: 14px;
        }

    select {
        padding: 5px;
        border-radius: 5px;
    }

    .buttons {
        display: flex;
        width: 100%;
    }

        .buttons .alignLeft {
            margin-right: auto;
        }

        .buttons .alignRight {
            margin-left: auto;
        }

    .control-bar button {
        border: none;
        display: flex;
        align-items: center;
        cursor: pointer;
        height: 30px;
        font-size: 14px;
        padding: 0px 10px;
        user-select: none;
        margin: 5px;
        min-width: 100px;
    }

    button.centerText {
        justify-content: center;
    }

    .flex-table tbody {
        overflow-y: scroll;
        max-height: 800px;
    }

    .flex-table ::-webkit-scrollbar {
        width: 0px; /* remove scrollbar space */
        background: transparent; /* optional: just make scrollbar invisible */
    }

    .flex-table,
    .flex-table thead,
    .flex-table tbody,
    .flex-table tfoot {
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        width: 100%;
        padding: 5px 10px;
    }

        .flex-table thead {
            border-bottom: 1px solid rgba(0, 0, 0, 0.25);
        }

            .flex-table thead > tr > td {
                font-weight: bold;
                height: auto;
                text-align: center;
            }

        .flex-table tr > td:not(:nth-last-of-type(1)) {
            border-right: 1px solid rgba(0, 0, 0, 0.25);
        }

        .flex-table tr {
            width: 100%;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 5px 0;
            transition-duration: 0.25s;
            min-height: 35px;
        }

        .flex-table > tbody tr:nth-last-of-type(1) {
            margin-bottom: 100px;
        }

        .flex-table td {
            font-size: 16px;
            width: 100%;
            padding: 0 10px;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }

        .flex-table tbody > tr:nth-of-type(odd) {
            background-color: rgba(0, 0, 255, 0.03);
        }

        .flex-table tbody > tr:hover {
            background-color: rgba(255, 235, 59, 0.2);
        }

    .title {
        font-size: 24px;
        margin-bottom: 10px;
    }

    .field {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        padding: 10px 0px;
    }

        .field > label {
            min-width: 150px;
        }

        .field > input[type="text"] {
            width: 100%;
            padding: 5px;
        }

    .form-buttons {
        display: flex;
        justify-content: flex-end;
        align-items: center;
    }

        .form-buttons > button {
            border: none;
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            height: 30px;
            font-size: 14px;
            padding: 0px 10px;
            user-select: none;
            margin: 5px;
            min-width: 100px;
        }
</style>
