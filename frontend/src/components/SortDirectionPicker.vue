<template>
  <q-expansion-item class="q-mx-md" icon="low_priority" label="Направление">
    <q-option-group
      v-model="sortDerection"
      type="radio"
      color="secondary"
      :options="[
        { label: 'По убыванию', value: false },
        { label: 'По возрастанию', value: true },
      ]"
    />
  </q-expansion-item>
</template>

<script>
import { ref } from "vue";

export default {
  name: "SortDirectionPicker",
  data() {
    return {
      sortDerection: ref(false),
    };
  },
};
</script>
