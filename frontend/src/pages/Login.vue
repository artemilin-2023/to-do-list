<template>
  <q-page padding>
    <div class="flex flex-center">
      <q-input
        class="q-ma-sm"
        style="width: 100%"
        v-model="email"
        type="email"
        label="Почта"
      />
      <password-input class="q-ma-sm" style="width: 100%" :label="'Пароль'" />
      <q-btn
        style="width: 100%"
        class="q-ma-sm"
        color="primary"
        label="Войти"
        @click="login()"
      />

      <q-btn
        class="q-mt-sm"
        size="sm"
        flat
        color="secondary"
        label="Не помню пароль"
        to="/auth/resetpassword"
      />
    </div>
  </q-page>
</template>

<script>
import PasswordInput from "components/PasswordInput.vue";
import { ref } from "vue";

export default {
  name: "LoginPage",
  components: { PasswordInput },

  data() {
    return {
      email: ref(""),
    };
  },

  methods: {
    login() {},
  },
};
</script>
