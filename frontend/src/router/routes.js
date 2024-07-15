import Login from "src/pages/Login.vue";
import Register from "src/pages/Register.vue";
import Friends from "src/pages/Friends.vue";
import GroupTasks from "src/pages/GroupTasks.vue";
import MyTasks from "src/pages/MyTasks.vue";
import Home from "src/pages/Home.vue";

import Main from "src/layouts/Main.vue";
import Authorize from "src/layouts/Authorize.vue";

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
    path: "/auth",
    component: Authorize,
    children: [
      { path: "/auth/login", alias: "/auth", component: Login },
      { path: "/auth/register", component: Register },
    ],
  },

  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/ErrorNotFound.vue"),
  },
];

export default routes;
