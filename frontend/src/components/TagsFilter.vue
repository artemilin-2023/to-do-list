<template>
  <q-expansion-item icon="tag" label="Теги">
    <div class="row">
      <tag-item
        v-for="tag in this.tags"
        ref="tag"
        :key="tag"
        :tag="tag"
        @toggle-tag="updateTagList($event)"
      />
      <q-chip
        :icon="this.selectedTags.length == 0 ? 'add' : 'clear_all'"
        :label="this.selectedTags.length == 0 ? 'Выбрать все' : 'Отчистить'"
        style="order: 1"
        clickable
        @click="
          () => {
            add = this.selectedTags.length == 0;
            this.$refs.tag.forEach((tag) => {
              if (add) {
                tag.add();
              } else {
                tag.clear();
              }
            });
          }
        "
      />
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
  methods: {
    updateTagList(tagEvent) {
      if (tagEvent.state) {
        this.selectedTags.push(tagEvent.tag);
      } else {
        this.selectedTags.splice(this.selectedTags.indexOf(tagEvent.tag), 1);
      }
    },
  },
};
</script>
