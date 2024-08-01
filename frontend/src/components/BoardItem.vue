<template>
  <q-card flat bordered class="row" style="height: 100%">
    <div
      class="column cursor-pointer"
      style="flex: 1 1 85%"
      v-on:click="openBoard()"
    >
      <q-card-section>
        <div class="text text-h6" style="max-width: 300px">
          {{ board.name }}
        </div>
        <div class="text text-subtitle1" style="max-width: 200px">
          {{ board.description }}
        </div>
      </q-card-section>
      <q-separator inset />
      <q-card-section class="row justify-start items-start">
        <q-chip
          class="tag"
          outline
          v-for="tag in board.tags"
          :key="tag"
          :icon="tag.icon"
          :color="tag.color"
          :label="tag.label"
        />
      </q-card-section>
    </div>
    <div class="column justify-center" style="flex: 1 1 15%">
      <q-btn
        class="col"
        flat
        color="red"
        icon="delete"
        @click="this.deleteConfirmation = true"
      >
        <q-tooltip label="Flip">Удалить</q-tooltip>
      </q-btn>
    </div>
  </q-card>

  <q-dialog v-model="deleteConfirmation" persistent>
    <q-card>
      <q-card-section class="row items-center">
        <q-avatar icon="delete" color="primary" text-color="white" />
        <span class="col q-ml-sm">
          Вы уверены, что хотите <strong>безвозвратно удалить</strong> доску и
          все связанные с ней задачи?
        </span>
      </q-card-section>
      <q-card-actions align="right">
        <q-btn flat label="Отменить" color="primary" v-close-popup />
        <q-btn
          flat
          label="Удалить"
          color="red"
          v-close-popup
          @click="deleteBoard()"
        />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script>
import { Board } from "src/api/DTOs/Board";
import { ref } from "vue";
import BoardApi from "src/api/BoardApi";

export default {
  name: "BoardItem",
  props: {
    board: Board,
  },
  data() {
    return {
      deleteConfirmation: ref(false),
    };
  },
  methods: {
    openBoard() {
      this.$router.push(`/boards/${this.board.id}`);
    },
    async deleteBoard() {
      const boardApi = new BoardApi(this.$api);
      console.log(await boardApi.delete(this.board.id));
    },
  },
};
</script>

<style>
.text {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
