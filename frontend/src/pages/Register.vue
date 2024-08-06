<template>
  <q-page padding class="flex justify-center items-center">
    <q-form
      ref="form"
      @submit="tryRegister()"
      @reset="reset()"
      class="flex column justify-center q-ma-sm"
    >
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
        <template v-slot:prepend> <q-icon name="mail_outline" /> </template
      ></q-input>
      <q-input
        v-model="nickname"
        type="text"
        label="Никнейм"
        :rules="[$rules.required('Никнейм обязателен для заполнения.')]"
      >
        <template v-slot:prepend>
          <q-icon name="person_outline" />
        </template>
      </q-input>
      <password-input
        ref="password"
        :label="'Пароль'"
        :rules="[
          $rules.required('Пароль обязателен для заполнения.'),
          $rules.minLength(6, 'Пароль слишком короткий.'),
        ]"
      />
      <password-input
        ref="confirmPassword"
        :label="'Повторите пароль'"
        :rules="[
          $rules.required('Пароль обязателен для заполнения.'),
          $rules.sameAs(
            this.$refs.password ? this.$refs.password.password : '',
            'Пароли не совпадают.'
          ),
        ]"
      />

      <q-item class="row">
        <q-item-section avatar>
          <q-toggle v-model="acceptPolicy" :true-value="true" />
        </q-item-section>
        <q-item-section class="col">
          <span>
            Нажимая, вы принимаете
            <a href="/policy#privacy">Политику обработки персональных данных</a>
          </span>
        </q-item-section>
      </q-item>

      <q-btn
        class="q-mt-sm"
        type="submit"
        color="primary"
        label="Зарегистрироваться"
      />
      <q-btn
        class="q-mt-sm"
        label="Сбросить"
        type="reset"
        color="secondary"
        flat
      />
    </q-form>
  </q-page>
</template>

<script>
import { useQuasar } from "quasar";
import PasswordInput from "src/components/PasswordInput.vue";
import { ref } from "vue";

export default {
  name: "RegisterPage",
  components: { PasswordInput },

  data() {
    return {
      email: ref(""),
      nickname: ref(""),
      acceptPolicy: ref(false),
    };
  },

  methods: {
    reset() {
      this.$refs.form.resetValidation();
      this.email = ref("");
      this.nickname = ref("");
      this.$refs.password.password = ref("");
      this.$refs.confirmPassword.password = ref("");
      this.acceptPolicy = false;
    },

    tryRegister() {
      this.$refs.form.validate().then((isSuccess) => {
        if (!this.acceptPolicy) {
          this.$q.notify({
            color: "red-5",
            textColor: "white",
            icon: "warning",
            message:
              "Для продолжения необходнимо принять полититку обработки данных.",
          });
          return;
        }

        if (isSuccess) {
          this.register();
        }
      });
    },

    register() {
      console.log("register");
    },
  },
};
</script>
