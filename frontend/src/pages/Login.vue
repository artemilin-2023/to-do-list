<template>
  <q-page padding>
    <div>
      <q-form class="flex flex-center" @submit="login()">
        <q-input
          class="q-ma-sm"
          style="width: 100%"
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
          class="q-ma-sm"
          style="width: 100%"
          :label="'Пароль'"
          :rules="[
            $rules.required('Пароль обязателен для заполнения.'),
            $rules.minLength(6, 'Пароль слишком короткий.'),
          ]"
        />
        <q-btn
          style="width: 100%"
          type="submit"
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
      </q-form>
    </div>
  </q-page>
</template>

<script>
import PasswordInput from "components/PasswordInput.vue";
import { Axios } from "axios";
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
    login() {
      this.$api
        .post("login", {
          email: this.email,
          password: this.$refs.passwordInput.password,
        })
        .then((result) => {
          console.log(result);
        });
    },
  },
};
</script>
