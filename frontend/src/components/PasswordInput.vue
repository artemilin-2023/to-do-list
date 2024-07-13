<template>
  <q-input
    v-model="password"
    :type="isPwd ? 'password' : 'text'"
    :label="label"
  >
    <template v-slot:prepend>
      <q-icon name="lock_outline" />
    </template>
    <template v-slot:append>
      <q-icon
        :name="isPwd ? 'visibility_off' : 'visibility'"
        class="cursor-pointer"
        @click="isPwd = !isPwd"
      />
    </template>
  </q-input>
</template>

<script>
import { ref } from "vue";

export default {
  props: {
    label: String,
  },

  data() {
    return {
      password: ref(""),
      isPwd: ref(true),
    };
  },
};
</script>
