<template>
  <q-page padding>
    <div class="column">
      <advertisement-block
        :block-id="'R-A-10819221-1'"
        :render-to="'yandex_rtb_R-A-10819221-1'"
      />
      <div class="row">
        <q-input
          v-on:keydown.enter="getBoards()"
          class="col q-mr-md"
          v-model="search"
          type="text"
          label="Найти"
        >
          <template v-slot:append>
            <q-icon
              v-if="this.search.length != 0"
              name="cancel"
              @click="
                () => {
                  this.search = '';
                  getBoards();
                }
              "
            />
            <q-icon name="search" @click="getBoards()" />
          </template>
        </q-input>
      </div>

      <div class="mobile-only column q-gutter-sm">
        <q-expansion-item expand-separator icon="filter_alt" label="Фильтрация">
          <board-type-picker ref="type-picker" class="q-mx-md" />
          <tags-filter ref="tags-picker" class="q-mx-md" />
          <date-range-picker ref="date-range-picker" class="q-mx-md" />
        </q-expansion-item>
        <q-expansion-item expand-separator icon="sort" label="Сортировка">
          <sort-direction-picker ref="sort-direction-picker" class="q-mx-md" />
          <order-by-picker ref="order-by-picker" class="q-mx-md" />
        </q-expansion-item>
      </div>

      <div class="desktop-only row q-gutter-md no-wrap">
        <board-type-picker ref="type-picker" class="col" />
        <tags-filter ref="tags-picker" class="col" />
        <date-range-picker ref="date-range-picker" class="col" />
        <sort-direction-picker ref="sort-direction-picker" class="col" />
        <order-by-picker ref="order-by-picker" class="col" />
      </div>

      <div v-if="!isLoad" class="row q-ma-md">
        <div class="q-ma-md" v-for="i in 20" :key="i" style="flex: 1 0 40%">
          <board-skeleton />
        </div>
      </div>
      <div v-else class="row q-ma-md">
        <div
          class="q-ma-md"
          style="flex: 1 0 25%"
          v-for="board in boards"
          :key="board"
        >
          <board-item :board="board" />
        </div>
      </div>
    </div>
  </q-page>
</template>

<script>
import { ref } from "vue";
import BoardItem from "src/components/BoardItem.vue";
import BoardSkeleton from "src/components/BoardSkeleton.vue";
import TagsFilter from "src/components/TagsFilter.vue";
import DateRangePicker from "src/components/DateRangePicker.vue";
import OrderByPicker from "src/components/OrderByPicker.vue";
import SortDirectionPicker from "src/components/SortDirectionPicker.vue";
import BoardTypePicker from "src/components/BoardTypePicker.vue";
import BoardApi from "src/api/BoardApi";
import AdvertisementBlock from "src/components/AdvertisementBlock.vue";

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
    AdvertisementBlock,
  },

  beforeMount() {
    this.boardApi = new BoardApi(this.$api);
  },

  setup() {
    const typePicker = ref();
    const tagPicker = ref();
    const dateRagePicker = ref();
    const sortDirectonPicker = ref();
    const orderByPicker = ref();

    return {
      typePicker,
      tagPicker,
      dateRagePicker,
      sortDirectonPicker,
      orderByPicker,
    };
  },

  data() {
    return {
      isLoad: ref(false),
      boards: ref([]),
      search: ref(""),
    };
  },
  methods: {
    async getBoards() {
      this.isLoad = false;
      console.log("here");
      console.log(this.typePicker);
      // this.boards = await this.boardApi.getAll();
      this.isLoad = true;
    },
  },
};
</script>
