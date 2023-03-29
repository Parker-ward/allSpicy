<template>
  <div class="container-fluid bg ">
    <img src="" alt="">
    <div class="row">
      <div class="col-md-12 text-center">
        <h1>ALL SPICY! </h1>
        <h2> "Get your spice on... or not.. be a wuss!"</h2>
      </div>
    </div>
  </div>

  <div class="container-fluid">
    <div class="row">
      <div v-for="r in recipes" class="col-md-4">
        <RecipeCard :recipe="r" />
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
import RecipeCard from '../components/RecipeCard.vue';

export default {
  setup() {
    onMounted(() => {
      getRecipes()
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { RecipeCard }
}
</script>

<style scoped lang="scss">
.bg {
  background-image: image("https://images.unsplash.com/photo-1478145046317-39f10e56b5e9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MjZ8fGZvb2R8ZW58MHx8MHx8&auto=format&fit=crop&w=800&q=60");

}
</style>
