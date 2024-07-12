<template>
  <q-page padding>
    <div class="flex flex-center">
      <q-input
        class="q-ma-sm"
        style="width: 100%"
        v-model="email"
        type="email"
        label="Почта"
        :error="v$.$dirty"
      />
      <q-input
        class="q-ma-sm"
        style="width: 100%"
        v-model="nickname"
        type="nickname"
        label="Никнейм"
      />
      <password-input
        ref="password"
        class="q-ma-sm"
        style="width: 100%"
        :label="'Пароль'"
      />
      <password-input
        ref="confirmPassword"
        class="q-ma-sm"
        style="width: 100%"
        :label="'Повторите пароль'"
      />
      <q-btn
        :disable="v$.$invalid"
        type="submit"
        style="width: 100%"
        class="q-ma-sm"
        color="primary"
        label="Зарегистрироваться"
        @click="register()"
      />
    </div>
  </q-page>
</template>

<script>
import PasswordInput from "src/components/PasswordInput.vue";
import { required } from "@vuelidate/validators";
import { ref } from "vue";
import useVuelidate from "@vuelidate/core";

export default {
  name: "RegisterPage",
  components: { PasswordInput },

  setup() {
    return {
      v$: useVuelidate(),
    };
  },

  data() {
    return {
      email: ref(""),
      nickname: ref(""),
    };
  },

  methods: {
    register() {},
  },

  validations() {
    return {
      email: {
        required,
        validFormat: (val) => /^\S+@\S+\.\S+$/,
        $autoDirty: true,
      },
      nickname: {
        required,
      },
    };
  },
};
</script>
