<template>
  <div class="container-fluid">
    <div class="row cover-img" :style="`background-image: url(${recipes.img})`">
      <div>
        <img :src="recipes.creator.picture" alt="">
      </div>
    </div>
  </div>
</template>


<script>
import { onMounted, computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js';
import { router } from '../router.js';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const route = useRoute()
    // const router = useRouter()
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
      recipes: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped></style>