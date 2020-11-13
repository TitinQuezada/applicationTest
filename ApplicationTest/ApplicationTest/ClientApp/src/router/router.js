import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import EditPermit from '../components/Permits/EditPermit/EditPermit.vue';
import CreatePermit from '../components/Permits/CreatePermit/CreatePermit.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/edit/:id',
    name: 'EditPermit',
    component: EditPermit,
  },
  {
    path: '/create',
    name: 'CreatePermit',
    component: CreatePermit,
  },
];

const router = new VueRouter({
  routes,
});

export default router;
