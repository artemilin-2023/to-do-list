<template>
  <q-layout view="hHh Lpr fFf">
    <div
      class="column flex-center q-ml-auto q-mr-auto"
      style="max-width: min-content"
    >
      <h1 class="q-mt-lg flex-center">ToDone</h1>

      <div class="flex-center">
        <q-btn-toggle
          v-model="path"
          toggle-color="primary"
          :options="[
            { label: 'вход', value: '/auth/login' },
            { label: 'регистрация', value: '/auth/register' },
          ]"
          @click="switchPage()"
        />
      </div>

      <q-page-container>
        <router-view />
      </q-page-container>
    </div>
  </q-layout>
</template>

<script>
import { ref } from "vue";
import { useQuasar } from "quasar";

export default {
  name: "AuthorizeLayout",

  setup() {
    const $q = useQuasar();
    var theme = localStorage.getItem("theme") === "true";
    $q.dark.set(theme);
  },

  data() {
    return {
      path: ref(this.$route.fullPath),
    };
  },

  methods: {
    switchPage() {
      this.$router.push(this.path);
    },
  },
};
</script>
