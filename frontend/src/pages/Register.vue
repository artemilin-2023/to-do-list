<template>
  <q-page padding>
    <div>
      <q-form
        ref="form"
        class="flex flex-center"
        @submit="tryRegister()"
        @reset="reset()"
      >
        <q-input
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
          <template v-slot:prepend> <q-icon name="mail_outline" /> </template
        ></q-input>
        <q-input
          style="width: 100%"
          v-model="nickname"
          type="nickname"
          label="Никнейм"
          :rules="[$rules.required('Никнейм обязателен для заполнения.')]"
        >
          <template v-slot:prepend>
            <q-icon name="person_outline" />
          </template>
        </q-input>
        <password-input
          ref="password"
          style="width: 100%"
          :label="'Пароль'"
          :rules="[
            $rules.required('Пароль обязателен для заполнения.'),
            $rules.minLength(6, 'Пароль слишком короткий.'),
          ]"
        />
        <password-input
          ref="confirmPassword"
          style="width: 100%"
          :label="'Повторите пароль'"
          :rules="[
            $rules.required('Пароль обязателен для заполнения.'),
            $rules.sameAs(
              this.$refs.password ? this.$refs.password.password : '',
              'Пароли не совпадают.'
            ),
          ]"
        />

        <div class="flex flex-center">
          <q-btn
            type="submit"
            style="width: 100%"
            class="q-ma-sm"
            color="primary"
            label="Зарегистрироваться"
          />
          <q-btn
            label="Сбросить"
            type="reset"
            color="secondary"
            style="width: 100%"
            flat
            class="q-ml-sm"
          />
        </div>
      </q-form>
    </div>
  </q-page>
</template>

<script>
import { email } from "@vuelidate/validators";
import PasswordInput from "src/components/PasswordInput.vue";
import { ref } from "vue";

export default {
  name: "RegisterPage",
  components: { PasswordInput },

  data() {
    return {
      email: ref(""),
      nickname: ref(""),
    };
  },

  methods: {
    reset() {
      this.$refs.form.resetValidation();
      this.email = ref("");
      this.nickname = ref("");
      this.$refs.password.password = ref("");
      this.$refs.confirmPassword.password = ref("");
    },

    tryRegister() {
      this.$refs.form.validate().then((isSuccess) => {
        if (isSuccess) {
          this.register();
        }
      });
    },

    register() {
      console.log("reg");
    },
  },
};
</script>
