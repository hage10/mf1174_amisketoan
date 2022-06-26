import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import EmployeeList from './view/employee/EmployeeList.vue'

import mitt from "mitt";
const emitter = mitt();

const misarouters = [
    { path: '/employee', component: EmployeeList },
]

const router = createRouter({
        history: createWebHistory(),
        routes: misarouters,
    })
    // createApp(App).use(router).mount('#app')
const app = createApp(App);
app.use(router);
app.config.globalProperties.emitter = emitter;
app.mount("#app");