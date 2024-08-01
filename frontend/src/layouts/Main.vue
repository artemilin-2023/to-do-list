<template>
  <q-layout view="hHh Lpr fFf">
    <q-header>
      <q-toolbar>
        <q-btn
          flat
          round
          dense
          icon="menu"
          @click="showSidePanel = !showSidePanel"
        />

        <q-toolbar-title>ToDone</q-toolbar-title>

        <q-btn-dropdown
          ref="account"
          unelevated
          flat
          rounded
          icon="account_circle"
        >
          <q-list>
            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="person" />
              </q-item-section>
              <q-item-section>Профиль</q-item-section>
            </q-item>
            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="settings" />
              </q-item-section>
              <q-item-section>Настройки</q-item-section>
            </q-item>
            <q-item clickable v-ripple @click="changTheme()">
              <q-item-section avatar>
                <q-icon :name="$q.dark.isActive ? 'dark_mode' : 'light_mode'" />
              </q-item-section>
              <q-item-section
                >{{
                  $q.dark.isActive ? "Тёмная" : "Светлая"
                }}
                тема</q-item-section
              >
            </q-item>
            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="logout" />
              </q-item-section>
              <q-item-section>Выйти</q-item-section>
            </q-item>
          </q-list>
        </q-btn-dropdown>
      </q-toolbar>
    </q-header>

    <q-footer reveal class="row justify-center">
      <div>
        <span>made with</span>
        <q-icon class="q-ml-xs q-mr-xs" name="favorite" color="red"></q-icon>
        <span>by</span>
        <q-icon
          class="q-ml-xs q-mr-xs"
          name="fa-solid fa-frog"
          color="green"
        ></q-icon>
      </div>
    </q-footer>

    <q-drawer
      v-model="showSidePanel"
      side="left"
      :mini="miniState"
      @mouseover="miniState = false"
      @mouseout="miniState = true"
      :width="200"
      :breakpoint="500"
      :class="$q.dark.isActive ? 'dark-page' : 'bg-indigo-3'"
    >
      <q-scroll-area class="fit" :horizontal-thumb-style="{ opacity: 0 }">
        <q-list padding separator>
          <q-item
            clickable
            v-ripple
            :active="currentPage === '/home'"
            @click="swapPage('/home')"
          >
            <q-item-section avatar> <q-icon name="home" /> </q-item-section>
            <q-item-section>Главная</q-item-section>
          </q-item>
          <q-item
            clickable
            v-ripple
            :active="currentPage === '/boards/new'"
            @click="swapPage('/boards/new')"
          >
            <q-item-section avatar> <q-icon name="add" /> </q-item-section>
            <q-item-section>Добавить доску</q-item-section>
          </q-item>
          <q-item
            clickable
            v-ripple
            :active="currentPage === '/friends'"
            @click="swapPage('/friends')"
          >
            <q-item-section avatar>
              <q-icon name="diversity_3" />
            </q-item-section>
            <q-item-section no-wrap>Друзья</q-item-section>
          </q-item>
        </q-list>
      </q-scroll-area>
    </q-drawer>

    <accept-cookies-banner :show="this.getCookieStatus()" />

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { useQuasar } from "quasar";
import AcceptCookiesBanner from "src/components/AcceptCookiesBanner.vue";
import { ref } from "vue";

export default {
  name: "MainLayout",
  components: { AcceptCookiesBanner },

  beforeMount() {
    this.currentPage = this.$route.fullPath;
  },
  updated() {
    this.currentPage = this.$route.fullPath;
  },

  setup() {
    const $q = useQuasar();
    var theme = localStorage.getItem("theme") === "true";
    $q.dark.set(theme);

    function changTheme() {
      $q.dark.toggle();
      localStorage.setItem("theme", $q.dark.isActive);
    }

    function getCookieStatus() {
      console.log(localStorage);
      return localStorage.getItem("acceptCookies") != null
        ? localStorage.getItem("acceptCookies") === "false"
        : true;
    }

    return { changTheme, getCookieStatus };
  },

  data() {
    return {
      showSidePanel: ref(false),
      miniState: ref(true),
      currentPage: ref("home"),
      showAccount: ref(false),
    };
  },
  methods: {
    swapPage(page) {
      this.$router.push(page);
    },
  },
};
</script>
