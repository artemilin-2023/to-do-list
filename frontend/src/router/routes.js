import Login from "src/pages/Login.vue";
import Register from "src/pages/Register.vue";
import Home from "src/layouts/Home.vue";
import Authorize from "src/layouts/Authorize.vue";

const routes = [
  {
    path: "/",
    component: Home,
  },
  {
    path: "/auth",
    component: Authorize,
    children: [
      { path: "", alias: "login", component: Login },
      { path: "", alias: "register", component: Register },
    ],
  },

  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/ErrorNotFound.vue"),
  },
];

export default routes;
