import Friends from "src/pages/Friends.vue";
import AddBoard from "src/pages/AddBoard.vue";
import Home from "src/pages/Home.vue";

import Main from "src/layouts/Main.vue";
import Authorize from "src/layouts/Authorize.vue";
import Login from "src/pages/Login.vue";
import Register from "src/pages/Register.vue";
import PolicyPage from "src/pages/PolicyPage.vue";

const routes = [
  {
    path: "/",
    component: Main,
    children: [
      { path: "/", alias: ["/home", "/"], component: Home },
      { path: "/boards/new", component: AddBoard },
      { path: "/friends", component: Friends },
      { path: "/policy", component: PolicyPage },
    ],
  },
  {
    path: "/auth/",
    component: Authorize,
    children: [
      { path: "login", alias: [""], component: Login },
      { path: "register", component: Register },
    ],
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
