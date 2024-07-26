<template>
  <div>
    <q-card flat bordered class="row" style="height: 100%">
      <div class="column" style="flex: 1 1 85%">
        <q-skeleton
          type="text"
          class="text-subtitle1 q-ma-sm"
          style="width: 50%"
        />
        <q-skeleton
          type="text"
          class="text-subtitle2 q-ml-sm"
          style="width: 35%"
        />
        <q-skeleton
          type="text"
          class="text-subtitle2 q-ml-sm"
          style="width: 25%"
        />
        <q-skeleton
          type="text"
          class="text-subtitle2 q-ml-sm"
          style="width: 30%"
        />
        <q-separator inset class="q-ma-xs" />
        <div class="row">
          <q-skeleton
            v-for="i in Math.floor(Math.random() * 4) + 1"
            :key="i"
            type="QChip"
            class="q-ma-sm"
          />
        </div>
      </div>
      <div class="column" style="flex: 1 1 15%">
        <q-skeleton type="rect" class="col q-ma-md" />
      </div>
    </q-card>
  </div>
</template>

<script>
export default {
  name: "BoardSceleton",
};
</script>
