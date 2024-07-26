<template>
  <q-chip
    class="cursor-pointer"
    :outline="!isSelected"
    :key="tag"
    :icon="tag.icon"
    :label="tag.label"
    :color="tag.color"
    clickable
    @click="toggle()"
    :style="{
      order: isSelected ? -1 : 0,
    }"
  />
</template>

<script>
import Tags from "src/api/enums/Tags";
import { ref } from "vue";

export default {
  name: "TagItem",
  props: {
    tag: Tags,
  },
  data() {
    return {
      isSelected: ref(false),
    };
  },
  methods: {
    toggle() {
      this.isSelected = !this.isSelected;
      console.log(this.isSelected);
    },
  },
};
</script>
