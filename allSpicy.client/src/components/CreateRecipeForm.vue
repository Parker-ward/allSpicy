<template>
  <form @submit.prevent="createRecipe()">
    <div class="modal-body text-dark">
      <div class="mb-3">
        <label for="name" class="form-label">Recipe</label>
        <input v-model="editable.name" required type="text" class="form-control" id="name" aria-describedby="emailHelp">
      </div>
    </div>
    <div class="modal-body text-dark">
      <div class="mb-3">
        <label for="name" class="form-label">Instructions</label>
        <input v-model="editable.name" required type="text" class="form-control" id="instructions"
          aria-describedby="emailHelp">
      </div>
    </div>
  </form>
</template>

<script>
export default {
  setup() {
    const editable = ref({})
    return {
    }
  }
}
</script>


<style lang="scss" scoped></style>