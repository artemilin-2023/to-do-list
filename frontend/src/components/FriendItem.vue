<template>
  <q-item
    class="row no-wrap"
    :style="`order: ${isSelected ? -1 : 1};`"
    :active="isSelected"
  >
    <q-item-section avatar style="flex: 8 1">
      <q-item>
        <q-item-section avatar>
          <q-avatar>
            <img :src="this.friend.avatar" />
          </q-avatar>
        </q-item-section>
        <q-item-section>
          <q-item-label class="nickname">
            {{ this.friend.nickname }}</q-item-label
          >
          <q-item-label class="email" caption lines="2"
            >{{ this.friend.email }}
          </q-item-label>
        </q-item-section>
      </q-item>
    </q-item-section>

    <q-item-section style="flex: 2 1">
      <q-btn
        :color="isSelected ? 'secondary' : 'primary'"
        :icon="isSelected ? 'person_remove' : 'group_add'"
        @click="
          () => {
            this.isSelected = !this.isSelected;
            this.$emit('add-or-delete-friend', {
              effect: this.isSelected,
              friend: this.friend,
            });
          }
        "
      />
    </q-item-section>
  </q-item>
</template>

<script>
import Friend from "src/api/DTOs/Friend";
import { ref } from "vue";

export default {
  name: "FriendItem",
  props: {
    friend: Friend,
  },
  data() {
    return {
      isSelected: ref(false),
    };
  },
  methods: {
    clear() {
      this.isSelected = false;
    },
  },
};
</script>

<style>
.nickname {
  max-width: 30ch;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
.email {
  max-width: 15ch;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
