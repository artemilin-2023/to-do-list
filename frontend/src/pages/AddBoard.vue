<template>
  <q-page padding>
    <div class="row justify-center">
      <q-card style="min-width: 100%">
        <q-form
          ref="form"
          class="row q-gutter-md q-mx-md q-my-sm"
          @submit="onSubmit"
          @reset="onReset"
        >
          <q-input
            style="flex: 1 1 100%"
            v-model="title"
            type="text"
            label="Название"
            :rules="[
              $rules.required('Поле обязательно для заполнения'),
              $rules.maxLength(
                30,
                'Название может содержавть максимум 30 символов'
              ),
            ]"
          />
          <q-input
            style="flex: 1 1 100%"
            v-model="description"
            type="textarea"
            label="Описание"
          />

          <tags-picker ref="tagsPicker" style="flex: 1 1 100%" default-opened />

          <q-toggle
            style="flex: 1 1 100%"
            v-model="isPublic"
            keep-color
            color="primary"
            :label="isPublic ? 'Совместная доска' : 'Личная доска'"
          />

          <friends-picker
            ref="friendsPicker"
            v-if="isPublic"
            style="flex: 1 1 100%"
          />

          <div style="flex: 1 1 100%" class="row justify-end q-gutter-sm">
            <q-btn
              label="Отчистить"
              type="reset"
              color="secondary"
              flat
              :disable="isLoad"
            />
            <q-btn
              label="Создать"
              type="submit"
              color="primary"
              :loading="isLoad"
            />
          </div>
        </q-form>
      </q-card>
    </div>
  </q-page>
</template>

<script>
import BoardApi from "src/api/BoardApi";
import FriendsPicker from "src/components/FriendsPicker.vue";
import TagsPicker from "src/components/TagsPicker.vue";
import { ref } from "vue";

export default {
  name: "AddBoard",
  components: { TagsPicker, FriendsPicker },

  mounted() {
    this.boardApi = new BoardApi(this.$api);
  },
  setup() {
    const tagsPicker = ref();
    const form = ref();
    const friendsPicker = ref();

    return {
      tagsPicker,
      form,
      friendsPicker,
    };
  },

  data() {
    return {
      title: ref(""),
      description: ref(""),
      isPublic: ref(false),
      isLoad: ref(false),
    };
  },

  methods: {
    async onSubmit() {
      this.isLoad = true;
      await this.boardApi.post(
        this.title,
        this.description,
        this.isPublic,
        this.tagsPicker.selectedTags,
        this.friendsPicker ? this.friendsPicker.selected : null
      );
      this.isLoad = false;
    },
    onReset() {
      if (this.isPublic) this.friendsPicker.clear();
      this.tagsPicker.clear();
      this.form.resetValidation();
      this.title = "";
      this.description = "";
    },
  },
};
</script>
