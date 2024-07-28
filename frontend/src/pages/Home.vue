<template>
  <q-page padding>
    <div class="column">
      <div class="row">
        <q-input
          class="col q-mr-md"
          v-model="search"
          type="search"
          label="Найти"
        >
          <template v-slot:append>
            <q-icon name="search" @click="searchTask()"></q-icon>
          </template>
        </q-input>
      </div>

      <div class="mobile-only column q-gutter-sm">
        <q-expansion-item expand-separator icon="filter_alt" label="Фильтрация">
          <board-type-picker class="q-mx-md" />
          <tags-filter class="q-mx-md" />
          <date-range-picker class="q-mx-md" />
        </q-expansion-item>
        <q-expansion-item expand-separator icon="sort" label="Сортировка">
          <sort-direction-picker class="q-mx-md" />
          <order-by-picker class="q-mx-md" />
        </q-expansion-item>
      </div>

      <div class="desktop-only row q-gutter-md no-wrap">
        <board-type-picker class="col" />
        <tags-filter class="col" />
        <date-range-picker class="col" />
        <sort-direction-picker class="col" />
        <order-by-picker class="col" />
      </div>

      <div v-if="!isLoad" class="row q-ma-md q-gutter-md">
        <div v-for="i in 20" :key="i" style="flex: 1 1 25%">
          <board-skeleton />
        </div>
      </div>
      <div v-else class="row q-ma-md q-gutter-md">
        <div style="flex: 1 1 25%" v-for="board in boards" :key="board">
          <board-item :board="board" />
        </div>
      </div>
    </div>
  </q-page>
</template>

<script>
import { ref } from "vue";
import BoardItem from "src/components/BoardItem.vue";
import { Board } from "src/api/DTOs/Board";
import Tags from "src/api/enums/Tags";
import BoardSkeleton from "src/components/BoardSkeleton.vue";
import TagsFilter from "src/components/TagsFilter.vue";
import DateRangePicker from "src/components/DateRangePicker.vue";
import OrderByPicker from "src/components/OrderByPicker.vue";
import SortDirectionPicker from "src/components/SortDirectionPicker.vue";
import BoardTypePicker from "src/components/BoardTypePicker.vue";

export default {
  name: "HomePage",
  components: {
    BoardItem,
    BoardSkeleton,
    TagsFilter,
    BoardTypePicker,
    DateRangePicker,
    OrderByPicker,
    SortDirectionPicker,
  },

  beforeMount() {
    this.getBoards();
  },

  data() {
    return {
      isLoad: ref(false),
      boards: ref([]),
      search: ref(""),
    };
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

    getBoards() {
      this.isLoad = false;
      new Promise((resolve) => setTimeout(resolve, 2 * 1000)).then(() => {
        var result = [];
        var tags = [
          Tags.EDUCATOIN,
          Tags.HOME,
          Tags.HOT,
          Tags.WORK,
          Tags.OTHER,
          Tags.PRIVATE,
          Tags.PUBLIC,
        ];
        for (var i = 0; i < 100; i++) {
          var cur_tags = [];
          var cur_tags_count = Math.floor(Math.random() * tags.length) + 1;
          for (var j = 0; j < cur_tags_count; j++) cur_tags.push(tags[j]);
          result.push(
            new Board(
              i,
              "name " + (i + 1),
              i % 2 == 0
                ? "some short description"
                : "some long long long long long long long long long long long long long long long long description",
              Date.now(),
              cur_tags
            )
          );
        }
        this.isLoad = ref(true);
        this.boards = result;
      });
    },
  },
};
</script>
