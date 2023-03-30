<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
    <div class="d-flex justify-content-end my-3 p-2 fixed-bottom">
      <button v-if="account.id" class="btn btn-success col-md-1" title="New Recipe" @click="createRecipe"
        data-bs-toggle="modal" data-bs-target="#exampleModalLabel"><i class="mdi mdi-plus"></i></button>
    </div>
  </main>
  <footer class="bg-dark text-light">
    Made THE SPICIEST
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState),
      account: computed(() => AppState.account)
    }
  },
  components: { Navbar },
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
