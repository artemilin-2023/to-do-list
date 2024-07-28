<template>
  <q-expansion-item class="q-mx-md" icon="sort_by_alpha" label="Сортировать по">
    <q-option-group
      v-model="sortKey"
      type="radio"
      color="secondary"
      :options="[
        { label: 'Названию', value: 'title' },
        { label: 'Дате создания', value: 'createdDate' },
      ]"
    />
  </q-expansion-item>
</template>

<script>
import { ref } from "vue";

export default {
  name: "OrderByPicker",
  data() {
    return {
      sortKey: ref("createdDate"),
    };
  },
};
</script>
