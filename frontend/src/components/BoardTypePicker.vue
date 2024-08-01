<template>
  <q-expansion-item icon="format_list_bulleted" label="Тип доски">
    <q-option-group
      v-model="type"
      type="radio"
      color="secondary"
      :options="[
        { label: 'Все', value: 'allTasks' },
        { label: 'Личная', value: 'privateTasks' },
        { label: 'Совместная', value: 'publicTasks' },
      ]"
    />
  </q-expansion-item>
</template>

<script>
import { ref } from "vue";

export default {
  name: "BoardTypePicker",
  data() {
    return {
      type: ref("allTasks"),
    };
  },
};
</script>
