<template>
  <q-expansion-item icon="format_list_bulleted" label="Тип задачи">
    <q-option-group
      v-model="taskType"
      type="radio"
      color="secondary"
      :options="[
        { label: 'Все', value: 'allTasks' },
        { label: 'Личные', value: 'privateTasks' },
        { label: 'Совместные', value: 'publicTasks' },
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
      taskType: ref("allTasks"),
    };
  },
};
</script>
