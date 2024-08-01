<template>
  <div :id="this.renderTo"></div>
</template>

<script setup>
import { onMounted } from "vue";

const props = defineProps({
  blockId: String,
  renderTo: String,
});

onMounted(() => {
  window.yaContextCb.push(() => {
    Ya.Context.AdvManager.render({
      blockId: props.blockId,
      renderTo: props.renderTo,
    });
  });
});
</script>
