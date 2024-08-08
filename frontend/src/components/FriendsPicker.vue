<template>
  <q-expansion-item expand-separator icon="group" label="Добавить друзей">
    <div class="column q-gutter-md">
      <q-input v-model="search" type="text" label="Поиск по нику">
        <template v-slot:append>
          <q-icon
            v-if="this.search.length != 0"
            name="cancel"
            @click="
              () => {
                this.search = '';
              }
            "
          />
        </template>
      </q-input>

      <q-list class="column items-start">
        <div
          v-if="friends.length == 0"
          class="row justify-center"
          style="width: 100%"
        >
          <q-item>
            <q-item-section>
              <span class="text">
                У вас нет друзей с таким ником
                <q-icon name="fa-regular fa-face-sad-cry" color="secondary" />
              </span>
            </q-item-section>
          </q-item>
        </div>
        <q-separator style="order: 0; height: 1px; width: 100%" />
        <friend-item
          style="width: 100%"
          v-for="friend in friends"
          :key="friend"
          :friend="friend"
        />
      </q-list>
    </div>
  </q-expansion-item>
</template>

<script>
import { ref } from "vue";
import Friend from "src/api/DTOs/Friend";
import FriendItem from "./FriendItem.vue";

export default {
  name: "FriendsPicker",
  components: { FriendItem },

  mounted() {
    this.getFriends();
  },

  data() {
    return {
      search: ref(""),
      friends: ref([]),
    };
  },
  watch: {
    search() {
      console.log(this.search);
    },
  },
  methods: {
    getFriends() {
      this.friends = [
        new Friend(
          1,
          "lcma",
          "qwerty.@lcma.xyz",
          "some bio",
          "https://cdn.quasar.dev/img/avatar2.jpg"
        ),
        new Friend(
          2,
          "y7o4ka",
          "hz@y7o4ka.xyz",
          "some bio",
          "https://cdn.quasar.dev/img/avatar1.jpg"
        ),
        new Friend(
          3,
          "pipup",
          "asdfasdfasdfafasdfasf@asdfasdf.asdf",
          "some bio",
          "https://cdn.quasar.dev/img/avatar3.jpg"
        ),
      ];
    },
  },
};
</script>
