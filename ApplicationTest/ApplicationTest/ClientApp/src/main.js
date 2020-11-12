import { createApp } from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'
import 'jquery/dist/jquery.js'

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

createApp(App).mount('#app')
const app = createApp(App)
app.use(VueAxios, axios)
