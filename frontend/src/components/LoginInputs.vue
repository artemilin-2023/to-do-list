<template>
  <q-form @submit="login" class="flex column justify-center q-ma-sm">
    <q-input
      v-model="email"
      type="email"
      label="Почта"
      lazy-rules
      :rules="[
        $rules.required('Почта обязательна для заполнения.'),
        $rules.email('Пожалуйста, введите настоящую почту.'),
      ]"
    >
      <template v-slot:prepend>
        <q-icon name="mail_outline" />
      </template>
    </q-input>
    <password-input
      ref="passwordInput"
      :label="'Пароль'"
      :rules="[
        $rules.required('Пароль обязателен для заполнения.'),
        $rules.minLength(6, 'Пароль слишком короткий.'),
      ]"
    />
    <q-btn
      class="q-mt-sm"
      :loading="isLoading"
      :disable="isLoading"
      type="submit"
      color="primary"
      label="Войти"
    />

    <q-btn
      class="q-mt-sm"
      size="sm"
      flat
      color="secondary"
      label="Не помню пароль"
      to="/auth/resetpassword"
    />
  </q-form>
</template>

<script>
import PasswordInput from "components/PasswordInput.vue";
import { Cookies } from "quasar";
import { ref } from "vue";

export default {
  name: "LoginPage",
  components: { PasswordInput },

  data() {
    return {
      email: ref(""),
      errorMessage: ref(""),
      isLoading: ref(false),
    };
  },

  methods: {
    login() {
      this.isLoading = ref(true);
      this.$api
        .post("login", {
          email: this.email,
          password: this.$refs.passwordInput.password,
        })
        .then((result) => {
          if (result.status == 200) {
            const cookies = Cookies.getAll();
            console.log(cookies);
            this.$router.push("/");
          }
          this.isLoading = ref(false);
        });
    },
  },
};
</script>

<style></style>
