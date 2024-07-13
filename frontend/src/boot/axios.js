import { boot } from "quasar/wrappers";
import axios from "axios";
import VueCookies from "vue-cookies";

// Be careful when using SSR for cross-request state pollution
// due to creating a Singleton instance here;
// If any client changes this (global) instance, it might be a
// good idea to move this instance creation inside of the
// "export default () => {}" function below (which runs individually
// for each client)
const api = axios.create({
  baseURL: "https://todo.lcma.xyz/api/v1",
  // baseURL: "https://localhost:7004/api/v1",
  headers: {
    "Access-Control-Allow-Headers":
      "Origin, X-Requested-With, Content-Type, Accept",
    Accept: "application/json",
    "Access-Control-Allow-Origin": "http://localhost:9000",
  },
  withCredentials: false,
});

export default boot(({ app }) => {
  // for use inside Vue files (Options API) through this.$axios and this.$api

  app.config.globalProperties.$axios = axios;
  // ^ ^ ^ this will allow you to use this.$axios (for Vue Options API form)
  //       so you won't necessarily have to import axios in each vue file

  app.config.globalProperties.$api = api;
  // ^ ^ ^ this will allow you to use this.$api (for Vue Options API form)
  //       so you can easily perform requests against your app's API
});

export { api };
