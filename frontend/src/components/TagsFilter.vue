<template>
  <q-expansion-item icon="tag" label="Теги">
    <div class="row">
      <tag-item v-for="tag in this.tags" :key="tag" :tag="tag" />
    </div>
  </q-expansion-item>
</template>

<script>
import Tags from "src/api/enums/Tags";
import { reactive, ref } from "vue";
import TagItem from "./TagItem.vue";

export default {
  name: "TagsFilter",
  components: { TagItem },
  setup() {
    const tags = reactive([]);
    for (let tag in Tags) {
      if (Tags[tag] != Tags.PRIVATE && Tags[tag] != Tags.PUBLIC)
        tags.push(Tags[tag]);
    }
    return { tags };
  },
  data() {
    return {
      selectedTags: ref([]),
    };
  },
};
</script>
