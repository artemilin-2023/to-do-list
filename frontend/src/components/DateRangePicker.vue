<template>
  <q-expansion-item icon="date_range" label="Период создания">
    <q-date
      :first-day-of-week="1"
      today-btn
      flat
      v-model="range"
      range
      style="width: 100%"
    />
  </q-expansion-item>
</template>

<script>
import { ref } from "vue";

export default {
  name: "DateRangePicker",
  data() {
    return {
      range: ref([]),
    };
  },
};
</script>
