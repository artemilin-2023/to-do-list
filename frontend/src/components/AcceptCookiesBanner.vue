<template>
  <q-dialog :model-value="show" position="bottom" persistent>
    <q-card>
      <q-card-section class="row items-center">
        <q-avatar icon="cookie" color="primary" text-color="white" />
        <span class="col q-ml-sm">
          Продолжая пользоваться сайтом, вы принимаете
          <a href="/policy#cookie">Политику файлов Cookie</a>
        </span>
      </q-card-section>
      <q-card-actions align="right">
        <q-btn
          flat
          label="Ok"
          color="primary"
          v-close-popup
          @click="acceptCookies()"
        />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script>
export default {
  name: "AcceptCookiesBanner",
  props: {
    show: Boolean,
  },

  setup() {
    function acceptCookies() {
      localStorage.setItem("acceptCookies", true);
    }

    return { acceptCookies };
  },
};
</script>
