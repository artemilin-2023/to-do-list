<template>
  <q-chip
    class="cursor-pointer"
    :outline="!isSelected"
    :key="tag"
    :icon="tag.icon"
    :label="tag.label"
    :color="tag.color"
    clickable
    @click="toggle(!isSelected)"
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
    toggle(mode) {
      this.isSelected = mode;
      this.$emit("toggleTag", { tag: this.tag, state: this.isSelected });
    },
    add() {
      this.toggle(true);
    },
    clear() {
      this.toggle(false);
    },
  },
};
</script>
