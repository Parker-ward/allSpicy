import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class RecipesService {

  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('[Getting recipes]', res.data)
    AppState.recipes = res.data
  }

  async getActiveRecipe(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`)
    logger.log('[GET ONE RECIPE]', res.data)
    AppState.activeRecipe = res.data
  }
}

export const recipesService = new RecipesService()