import Friends from "src/pages/Friends.vue";
import GroupTasks from "src/pages/GroupTasks.vue";
import MyTasks from "src/pages/MyTasks.vue";
import Home from "src/pages/Home.vue";
import Register from "src/layouts/Register.vue";

import Main from "src/layouts/Main.vue";
import Login from "src/layouts/Login.vue";

const routes = [
  {
    path: "/",
    component: Main,
    children: [
      { path: "/", alias: ["/home", "/"], component: Home },
      { path: "/my-tasks", component: MyTasks },
      { path: "/group-tasks", component: GroupTasks },
      { path: "/friends", component: Friends },
    ],
  },
  {
    path: "/auth/login",
    component: Login,
  },
  {
    path: "/auth/register",
    component: Register,
  },

  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/ErrorNotFound.vue"),
  },
];

export default routes;
