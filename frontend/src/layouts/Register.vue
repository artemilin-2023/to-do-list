<template>
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

    <register-inputs />
  </div>
</template>

<script>
import { ref } from "vue";
import { useQuasar } from "quasar";
import RegisterInputs from "components/RegisterInputs.vue";

export default {
  name: "RegisterLayout",
  components: { RegisterInputs },

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
