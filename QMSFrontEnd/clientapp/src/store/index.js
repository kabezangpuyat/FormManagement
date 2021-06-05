import Vue from 'vue';
import Vuex from 'vuex';

import PersistedState from 'vuex-persistedstate'; //this will not clear the state when you refresh the page

Vue.use(Vuex);

const getDefaultState = () => {
    return {
        loggeduser: {},
        isAuthenticated: false,
        qmsApiHost: "https://localhost:5011",
        token: '',
        roles: [],
        expirydatetime:'',
        fullname: '',
        appNavigations:[],
        pingclientid: 'ce8cc798-95f5-4a8f-8833-692deceb8e90',
        pingclientsecret: '9cSGVyFYczss2I1CEq5G9GYIeiFUplCFaMRhKGzx7gAqfJGAFQb6jDcJGO5eLKoEE',
        employeeNumber: '',
        formtoedit: {},
        audittoview: {}
    }
};

// initial state
const state = getDefaultState();

const store = new Vuex.Store({
    state,
    getters: {
        getLoggedUser: state => {
            return state.loggeduser;
        },
        getIsAuthenticated: state => {
            return state.isAuthenticated;
        },
        getQmsApiHost: state=>{
          return state.qmsApiHost;
        },
        getToken: state => {
          return state.token;
        },
        getRoles: state => {
          return state.roles;
        },
        getExpiryDatetime: state => {
          return state.expirydatetime;
        },
        getFullname: state =>{
          return state.fullname;
        },
        getNavigations: state =>{
          return state.appNavigations;
        },
        getPingClientId: state => {
          return state.pingclientid;
        },
        getPingClientSecret: state => {
          return state.pingclientsecret;
        },
        getEmployeeNumber: state => {
          return state.employeeNumber;
        },
        getformtoedit: state=>{
          return state.formtoedit;
        },
        getaudittoview: state=>{
          return state.audittoview;
        }
    },
    mutations: {
        login(state, loggedUser) {
          if(Object.keys(loggedUser).length > 0){
            window.localStorage.setItem('logged_user', JSON.stringify(loggedUser));
            state.loggeduser = loggedUser;
            state.isAuthenticated = true;
            state.token = loggedUser.jwtToken;
            state.roles = loggedUser.roles;
            state.fullname = loggedUser.lastName + ', ' + loggedUser.firstName;
            state.expirydatetime = loggedUser.expiryDate;
            state.appNavigations = loggedUser.appNavigations;
            state.employeeNumber = loggedUser.username;
          }           
        },
        clearData(state) {
           Object.assign(state, getDefaultState())
            window.localStorage.removeItem('logged_user');
        },
        setformtoedit(state,formDetails){
          state.formtoedit = formDetails;
        },
        clearformtoedit(state){
          state.formtoedit={};
        },
        setaudittoview(state,auditdetails){
          state.audittoview = auditdetails;
        },
        clearaudittoview(state){
          state.audittoview={};
        }
    },
    plugins: [PersistedState()],
    actions: {
  
    }
});

export default store;