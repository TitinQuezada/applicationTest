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
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ '../views/About.vue'),
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
