<template>
  <q-layout view="hHh Lpr fFf">
    <div class="flex column justify-center items-center" style="height: 100vh">
      <h1 class="q-mt-sm">ToDone</h1>

      <q-btn-toggle
        v-model="path"
        toggle-color="primary"
        :options="[
          { label: 'вход', value: '/auth/login' },
          { label: 'регистрация', value: '/auth/register' },
        ]"
        @click="switchPage()"
      />

      <login-inputs /></div
  ></q-layout>
</template>

<script>
import { ref } from "vue";
import { useQuasar } from "quasar";
import LoginInputs from "src/components/LoginInputs.vue";

export default {
  name: "AuthorizeLayout",
  components: { LoginInputs },

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
