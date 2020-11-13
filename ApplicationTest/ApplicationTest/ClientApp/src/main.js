import { createApp } from 'vue';
import App from './App.vue';
import 'jquery/dist/jquery.js';
import 'popper.js';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import router from '../src/Router';
import { MdDialogConfirm } from 'vue-material/dist/components'
////import 'vue-material/dist/vue-material.min.css'
//import 'vue-material/dist/theme/default.css'

const app = createApp(App).use(router)//.use(MdDialogConfirm);

app.mount('#app');
app.use(MdDialogConfirm)

