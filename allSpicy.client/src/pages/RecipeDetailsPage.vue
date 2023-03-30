<template>
  <div v-if="recipe" class="container-fluid">
    <div class="row bg-img">
      <div class="col-md-12 bg-img text-center" :style="`background-image: url(${recipe.img})`">
        <img :src="recipe.creator.picture" class="rounded-circle" alt="">
        <h2 class="text-light">{{ recipe.creator.name }}</h2>
      </div>
      <div>
        <div class="text-dark text-center">
          <h1> TITLE: </h1>
          <h3 class="text-dark text-center"> {{ recipe.title }}</h3>
        </div>
        <div class="elevation-2 my-3 bg-dark rounded">
          <h1 class="text-light text-center"> INSTRUCTIONS:</h1>
          <h3 class="text-light text-center">{{ recipe.instructions }}</h3>
        </div>
      </div>
    </div>
    Recipes detail page
  </div>
</template>


<script>
import { onMounted, computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const route = useRoute()
    const router = useRouter()
    onMounted(() => {
      getActiveRecipe()
    })
    async function getActiveRecipe() {
      try {
        await recipesService.getActiveRecipe(route.params.recipeId)
      } catch (error) {
        logger.error(error)
        Pop.error(error.message)
        router.push({ name: 'Home' })
      }
    }
    return {
      recipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>
.bg-img {
  background-size: cover;
  background-position: center;
  color: white;
}
</style>