<template>
  <q-card flat bordered class="row" style="height: 100%">
    <div
      class="column cursor-pointer"
      style="flex: 1 1 85%"
      v-on:click="openBoard()"
    >
      <q-card-section>
        <div class="text-h6">{{ board.name }}</div>
        <div class="description text-subtitle1">
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
      <!-- <q-btn class="col" flat color="accent" icon="open_in_new">
        <q-tooltip>Перейти к доске</q-tooltip>
      </q-btn> -->
      <q-btn class="col" flat color="red" icon="delete">
        <q-tooltip label="Flip">Удалить</q-tooltip>
      </q-btn>
    </div>
  </q-card>
</template>

<script>
import { Board } from "src/api/DTOs/Board";

export default {
  name: "BoardItem",
  props: {
    board: Board,
  },
  methods: {
    openBoard() {
      this.$router.push(`/boards/${this.board.id}`);
    },
  },
};
</script>

<style>
.description {
  max-width: 200px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
