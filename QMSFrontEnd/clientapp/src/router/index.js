import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

let mainChildren = [
    {
        path: '/admin/usermanagement',
        name: 'user',
        displayname: 'User',
        component: () => import('@/components/admin/user.vue'),
        meta: {
            icon: 'user-circle'
        }
    },
    {
        path: '/admin/form-admin',
        name: 'form-admin',
        displayname: 'Form Management',
        component: () => import('@/components/admin/form-admin.vue'),
        meta: {
            icon: 'tasks'
        }
    },
    {
        path: '/admin/form-create',
        name: 'form-create',
        displayname: 'Form Create',
        component: () => import('@/components/admin/form-create.vue'),
        meta: {
            icon: 'briefcase'
        }
    },
    {
        path: '/admin/audit-details-view',
        name: 'audit-details-view',
        displayname: 'Form Create',
        component: () => import('@/components/admin/audit-details-view.vue'),
        meta: {
            icon: 'briefcase'
        }
    },
    {
        path: '/admin/form-update',
        name: 'form-update',
        displayname: 'Form Update',
        component: () => import('@/components/admin/form-update.vue'),
        meta: {
            icon: 'briefcase'
        }
    },
    {
        path: '/admin/report-admin',
        name: 'report-admin',
        displayname: 'Report',
        component: () => import('@/components/admin/report-admin.vue'),
        meta: {
            icon: 'chart-area'
        }
    },
    {
        path: '/qa/form-qa',
        name: 'form-qa',
        displayname: 'Form Mangemetn',
        component: () => import('@/components/qa/form-qa.vue'),
        meta: {
            icon: 'align-left'
        }
    },
    {
        path: '/qa/form-createupdate-qa',
        name: 'form-createupdate-qa',
        displayname: 'Form Create/Update',
        component: () => import('@/components/qa/form-createupdate-qa.vue'),
        meta: {
            icon: 'align-left'
        }
    },
    {
        path: '/qa/audit-qa',
        name: 'audit-qa',
        displayname: 'Audit',
        component: () => import('@/components/qa/audit-qa'),
        meta: {
            icon: 'chart-area'
        }
    },
    {
        path: '/qa/audit-create',
        name: 'audit-create',
        displayname: 'Audit Create',
        component: () => import('@/components/qa/audit-create'),
        meta: {
            icon: 'align-justify'
        }
    },
    {
        path: '/qa/report-qa',
        name: 'report-qa',
        displayname: 'Report',
        component: () => import('@/components/qa/report-qa'),
        meta: {
            icon: 'table'
        }
    },
    {
        path: '/tl/report-tl',
        name: 'report-tl',
        displayname: 'Audit',
        component: () => import('@/components/tl/report-tl'),
        meta: {
            icon: 'chart-area'
        }
    },
    {
        path: '/tm/report-TM',
        name: 'report-TM',
        displayname: 'Audit',
        component: () => import('@/components/tm/report-TM'),
        meta: {
            icon: 'chart-area'
        }
    },
];

var router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        // {
        //     path: '/',
        //     redirect: '/login'
        // },
        {
            path: '/',
            redirect: '/login2',
            component: () => import('@/components/main.vue'),
            children: mainChildren,
            meta: {
                requiresAuth: false
            },  
        },
        {
            path: '/login',
            name: 'login',
            component: () => import('@/components/login.vue'),
            meta: {
                requiresAuth: false
            }
        },
        {
            path: '/login2',
            name: 'login2',
            component: () => import('@/components/login2.vue'),
            meta: {
                requiresAuth: false
            }
        }
    ]
});

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
       if (window.localStorage.getItem('logged_user') == null) {
           next({
               path: '/login',
               params: { nextUrl: to.fullPath }
           });
       } 
    //    else {
    //        let user = JSON.parse(window.localStorage.getItem('user_data'));
    //        if (user.isPOC) {
    //            next();
    //        } else {
    //            next({
    //                path: '/unauthorized',
    //                params: { nextUrl: to.fullPath }
    //            });
    //        }
    //    }
    } else {
       next();
    }
    // next();

});



export default router;

