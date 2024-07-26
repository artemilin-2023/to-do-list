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
          <q-expansion-item
            class="q-mx-md"
            icon="format_list_bulleted"
            label="Тип задачи"
          >
            <q-option-group
              v-model="taskType"
              type="radio"
              color="secondary"
              :options="[
                { label: 'Все', value: 'allTasks' },
                { label: 'Личные', value: 'privateTasks' },
                { label: 'Совместные', value: 'publicTasks' },
              ]"
            />
          </q-expansion-item>
          <tags-filter class="q-mx-md" />
          <q-expansion-item
            class="q-mx-md"
            icon="date_range"
            label="Период создания"
          >
            <div>
              <q-date
                :first-day-of-week="1"
                today-btn
                flat
                v-model="range"
                range
              />
            </div>
          </q-expansion-item>
        </q-expansion-item>
        <q-expansion-item expand-separator icon="sort" label="Сортировка">
          <q-expansion-item
            class="q-mx-md"
            icon="low_priority"
            label="Направление"
          >
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
          <q-expansion-item
            class="q-mx-md"
            icon="sort_by_alpha"
            label="Сортировать по"
          >
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
        </q-expansion-item>
      </div>

      <div class="desktop-only row q-gutter-md no-wrap">
        <q-expansion-item
          class="col"
          icon="format_list_bulleted"
          label="Тип задачи"
        >
          <q-option-group
            class="col"
            v-model="taskType"
            type="radio"
            color="secondary"
            :options="[
              { label: 'Все', value: 'allTasks' },
              { label: 'Личные', value: 'privateTasks' },
              { label: 'Совместные', value: 'publicTasks' },
            ]"
          />
        </q-expansion-item>
        <tags-filter class="col" />
        <q-expansion-item class="col" icon="date_range" label="Период создания">
          <div class="row">
            <q-date
              class="col"
              :first-day-of-week="1"
              today-btn
              flat
              v-model="range"
              range
            />
          </div>
        </q-expansion-item>
        <q-expansion-item class="col" icon="sort" label="Направление">
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
        <q-expansion-item
          class="col"
          icon="sort_by_alpha"
          label="Сортировать по"
        >
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

export default {
  name: "HomePage",
  components: { BoardItem, BoardSkeleton, TagsFilter },

  beforeMount() {
    this.getBoards();
  },

  data() {
    return {
      isLoad: ref(false),
      boards: ref([]),
      search: ref(""),
      taskType: ref("allTasks"),
      range: ref(null),
      sortDerection: ref(true),
      sortKey: ref("createdDate"),
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
