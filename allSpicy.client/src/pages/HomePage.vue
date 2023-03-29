<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-4">
        {{ recipes.name }}
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js'
import { onMounted, computed } from 'vue';

export default {
  setup() {
    onMounted(() => {
      getRecipes()
    })
    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss"></style>
