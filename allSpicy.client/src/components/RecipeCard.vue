<template>
  <div class="pt-3 pb-2">
    <div class="containter-fluid rounded elevation-1">
      <router-link :to="{ name: 'RecipeDetails', params: { recipeId: recipes.id } }">
        <img class="img-fluid rounded-top" :src="recipes.img" alt="">
        <h4 class="p-2 text-dark text-center">{{ recipes.name }}</h4>
        <div class="d-flex justify-content-between p-3 fw-bold text-info"><span> {{ recipes.category }}</span></div>
      </router-link>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState.js';

export default {
  props: { recipes: { type: Object, required: true } },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>