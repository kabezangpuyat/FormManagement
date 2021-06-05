import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';

//vue dialog
import VuejsDialog from 'vuejs-dialog';
// import VuejsDialogMixin from 'vuejs-dialog/dist/vuejs-dialog-mixin.min.js'; // only needed in custom components
// include the default style
import 'vuejs-dialog/dist/vuejs-dialog.min.css';
// Tell Vue to install the plugin.
Vue.use(VuejsDialog);

//dx data grid css
import 'devextreme/dist/css/dx.common.css';
import 'devextreme/dist/css/dx.light.css';

//composition api
import VueCompositionAPI from '@vue/composition-api';
Vue.use(VueCompositionAPI);
//foreawesome
import { library } from '@fortawesome/fontawesome-svg-core';
import { faUserSecret } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import solid from "@fortawesome/fontawesome-free-solid";
import regular from "@fortawesome/fontawesome-free-regular";

library.add(faUserSecret, solid, regular);
Vue.component('font-awesome-icon', FontAwesomeIcon);
//axios
import axios from 'axios';
import VueAxios from 'vue-axios';
Vue.use(VueAxios, axios);
//mutliselect
import multiselect from 'vue-multiselect';
Vue.component('multiselect', multiselect);
//vtooltip
import VTooltip from 'v-tooltip';
Vue.use(VTooltip);
//modal
import VModal from 'vue-js-modal';
Vue.use(VModal, { dynamic: true, dialog: true });
//toast
import Toasted from 'vue-toasted';
Vue.use(Toasted, {
  position: "top-center",
  duration: 3000,
  singleton: true
});

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
