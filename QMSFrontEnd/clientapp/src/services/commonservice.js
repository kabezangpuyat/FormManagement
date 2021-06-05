import store from '@/store';
import router from '@/router';
// import axios from 'axios';

class commonservice{
    
    constructor(){
        // super();
    }
    validateTokenUrl(){
        let expiry = this.getTokenExpiry();
        let validateUrl = this.getApiHost(`/api/Account/validateexpiry/${expiry}`);  
        return validateUrl;     
    }
    getTokenExpiry(){
        return store.state.expirydatetime;
    }
    getToken(){
        return store.state.token;
    }
    getEmployeeNumber(){
        return store.state.employeeNumber;
    }
    getPingClientId(){
        let clientId = store.state.pingclientid;
        return clientId;
    }
    getAppNavigations(){
        return store.state.appNavigations;
    }
    getRouteNavigations(){
        return router.options.routes.find(x => x.path == '/')
                .children;
    }
    getLoggedRoleId(){
        return store.getters.getRoles[0].id;
    }
    getAllNavigations(){
        let routeNavigation = this.getRouteNavigations();
        let appNavigations = this.getAppNavigations();//navigation from DB
        let result = routeNavigation.filter(function (o1) {
            return appNavigations.some(function (o2) {
                return o1.name === o2.name && o2.isMainModule===true; // return the ones with equal name
            });
        });
        return result;
    }
    getallformurl(){
        let url = this.getApiHost('/api/Form/get-all-active');
        if(this.getLoggedRoleId()==2){
            //QA
            url = this.getApiHost('/api/Form/get-all-by-logged-user');
        }

        return url;
    }
    getUrlParamValue(urlQueryParam){
        let urlParams = new URLSearchParams(window.location.search);
        let result = urlParams.get(urlQueryParam);

        return result;
    }
    getApiHost(endpoint){
        //DEV
        // return store.state.qmsApiHost + endpoint;
        //PROD
        return endpoint;
    }
    clearData(){
        store.commit('clearData');
        store.commit('clearformtoedit');  
    }
    storeLoginData(result){
        store.commit('login',result.data);
    }
    isAuthenticated(){
        return store.state.isAuthenticated;
    }
    
    redirect(routePath){
        router.push({ path: routePath });
    }
    redirectByName(routeName){
        router.push({ name: routeName });
    }
    redirecttoping(){
        let clientId = this.getPingClientId();
        window.location.href = 'https://sso.connect.pingidentity.com/sso/as/authorization.oauth2?client_id=' + clientId + '&scope=openid&response_type=code';   
    }
    logoutIfUnAuthorize(){
        if(this.isAuthenticated()==false){
            this.redirectByName('login');
        }
    }
    isAuthorized(){
        let routename = this.$route.name;
                
        let appNavigations = store.state.appNavigations//navigation from DB
        let isAuthorized = appNavigations.some(function(el) {
            return el.name === routename;
        });

        return isAuthorized;
    }
}

export default new commonservice();