<template>
  <q-page padding class="flex q-ma-xl">
    <q-input style="width: 100%" v-model="search" type="search" label="Найти">
      <template v-slot:append>
        <q-icon name="search" @click="searchTask()"></q-icon>
      </template>
    </q-input>
    <q-select
      v-model="taskType"
      :options="['Все', 'Личные', 'Совместные']"
      label="Задачи"
      filled
    />
  </q-page>
</template>

<script>
import { ref } from "vue";

export default {
  name: "HomePage",

  data() {
    return { search: ref(""), taskType: ref("Все") };
  },
  watch: {
    search() {
      this.searchTask();
    },
  },
  methods: {
    searchTask() {
      console.log(this.search);
    },
  },
};
</script>
