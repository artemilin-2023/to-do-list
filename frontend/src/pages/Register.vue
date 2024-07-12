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
      <q-input
        class="q-ma-sm"
        style="width: 100%"
        v-model="text"
        type="email"
        label="Никнейм"
      />
      <password-input class="q-ma-sm" style="width: 100%" :label="'Пароль'" />
      <password-input
        class="q-ma-sm"
        style="width: 100%"
        :label="'Повторите пароль'"
      />
      <q-btn
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

export default {
  name: "RegisterPage",
  components: { PasswordInput },

  data() {
    return {};
  },
};
</script>
