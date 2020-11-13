import { createWebHistory, createRouter } from 'vue-router';
import Home from './components/Home.vue';
import EditPermit from './components/EditPermit.vue';


const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/edit/:id',
        name: 'Edit',
        component: EditPermit,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
