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

export default {
  name: "AuthorizeLayout",

  data() {
    return {
      path: ref("/auth/login"),
    };
  },

  methods: {
    switchPage() {
      this.$router.push(this.path);
    },
  },
};
</script>
