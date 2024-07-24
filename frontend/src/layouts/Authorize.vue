<template>
  <q-layout view="hHh Lpr fFf">
    <q-header reveal>
      <q-toolbar class="row items-center justify-center">
        <q-toolbar-title> ToDone </q-toolbar-title>
      </q-toolbar>
    </q-header>
    <div class="column justify-center items-center">
      <q-page-container>
        <div class="flex justify-center items-center">
          <router-view />
        </div>
      </q-page-container>
    </div>
  </q-layout>
</template>

<script>
import { useQuasar } from "quasar";

export default {
  name: "AuthorizeLayout",

  setup() {
    const $q = useQuasar();
    var theme = localStorage.getItem("theme") === "true";
    $q.dark.set(theme);
  },
};
</script>
