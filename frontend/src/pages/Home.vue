<template>
  <q-page padding>
    <div class="column">
      <!-- <advertisement-block
        :block-id="'R-A-10819221-1'"
        :render-to="'yandex_rtb_R-A-10819221-1'"
      /> -->
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
          <board-type-picker ref="typePicker" class="q-mx-md" />
          <tags-picker ref="tagsPicker" class="q-mx-md" />
          <date-range-picker ref="dateRangePicker" class="q-mx-md" />
        </q-expansion-item>
        <q-expansion-item expand-separator icon="sort" label="Сортировка">
          <sort-direction-picker ref="sortDirectionPicker" class="q-mx-md" />
          <order-by-picker ref="orderByPicker" class="q-mx-md" />
        </q-expansion-item>
      </div>

      <div class="desktop-only row q-gutter-md no-wrap">
        <board-type-picker ref="typePicker" class="col" />
        <tags-picker ref="tagsPicker" class="col" />
        <date-range-picker ref="dateRangePicker" class="col" />
        <sort-direction-picker ref="sortDirectionPicker" class="col" />
        <order-by-picker ref="orderByPicker" class="col" />
      </div>

      <div v-if="!isLoad" class="row q-ma-md">
        <div class="q-ma-md" v-for="i in 20" :key="i" style="flex: 1 0 40%">
          <board-skeleton />
        </div>
      </div>
      <div v-else class="row q-ma-md">
        <div v-if="this.boards.length > 0">
          <div
            class="q-ma-md"
            style="flex: 1 0 25%"
            v-for="board in boards"
            :key="board"
          >
            <board-item :board="board" />
          </div>
        </div>
        <q-btn
          v-else
          style="flex: 1"
          color="primary"
          icon="add"
          label="Добавить новую доску."
          to="/boards/new"
        />
      </div>

      <error-dialog :message="errorMesage" :showDialog="hasError" />
    </div>
  </q-page>
</template>

<script>
import { ref } from "vue";
import BoardItem from "src/components/BoardItem.vue";
import BoardSkeleton from "src/components/BoardSkeleton.vue";
import TagsPicker from "src/components/TagsPicker.vue";
import DateRangePicker from "src/components/DateRangePicker.vue";
import OrderByPicker from "src/components/OrderByPicker.vue";
import SortDirectionPicker from "src/components/SortDirectionPicker.vue";
import BoardTypePicker from "src/components/BoardTypePicker.vue";
import BoardApi from "src/api/BoardApi";
import AdvertisementBlock from "src/components/AdvertisementBlock.vue";
import ErrorDialog from "src/components/ErrorDialog.vue";

export default {
  name: "HomePage",
  components: {
    BoardItem,
    BoardSkeleton,
    TagsPicker,
    BoardTypePicker,
    DateRangePicker,
    OrderByPicker,
    SortDirectionPicker,
    ErrorDialog,
    // AdvertisementBlock,
  },

  mounted() {
    this.boardApi = new BoardApi(this.$api);
    this.getBoards();
  },

  setup() {
    const typePicker = ref();
    const tagsPicker = ref();
    const dateRangePicker = ref();
    const sortDirectonPicker = ref();
    const orderByPicker = ref();

    return {
      typePicker,
      tagsPicker,
      dateRangePicker,
      sortDirectonPicker,
      orderByPicker,
    };
  },

  data() {
    return {
      isLoad: ref(false),
      boards: ref([]),
      search: ref(""),
      errorMesage: ref(""),
      hasError: ref(false),
    };
  },
  methods: {
    async getBoards() {
      this.isLoad = false;
      const response = await this.boardApi.getAll(
        this.search,
        this.tagsPicker.selectedTags,
        this.dateRangePicker.range,
        this.typePicker.type
      );

      if (response.isSuccess) {
        this.boards = response.data;
        this.isLoad = true;
      } else {
        this.errorMesage = response.errorMesage
          ? response.errorMesage
          : "Непредвиденная ошибка сервера.";
        this.hasError = true;
      }
    },
  },
};
</script>
