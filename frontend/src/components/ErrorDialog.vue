<template>
  <q-dialog :model-value="showDialog" auto-close>
    <q-card>
      <q-card-section class="row">
        <q-avatar icon="error" color="primary" text-color="white" />
        <div class="col column q-ml-sm">
          <span> Упс! Во время выполнения запроса возникла ошибка: </span>
          <span>{{ message }}</span>
        </div>
      </q-card-section>
      <q-card-actions align="right">
        <q-btn flat label="Ок" color="primary" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script>
export default {
  name: "ErrorDialog",
  props: {
    message: String,
    showDialog: Boolean,
  },
};
</script>
