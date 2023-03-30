<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
    <div class="d-flex justify-content-end my-3 p-2">
      <button class="btn btn-success col-md-1" title="New Recipe"> <i class="mdi mdi-plus"></i></button>
    </div>
  </main>
  <footer class="bg-dark text-light">
    Made with 💖
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
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
