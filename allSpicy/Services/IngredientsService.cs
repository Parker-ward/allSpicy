namespace allSpicy.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      Ingredient ingredient = _repo.CreateIngredient(ingredientData);
      return ingredient;
    }

    internal List<Ingredient> FindByRecipe(int recipeId)
    {
      List<Ingredient> ingredients = _repo.FindByRecipe(recipeId);
      return ingredients;
    }

    internal string removeIngredient(int recipeId, string userId)
    {
      Ingredient ingredient = _repo.FindIngredient(recipeId);
      if (ingredient.CreatorId != userId) throw new Exception($"not ingredient with that {recipeId}");
      _repo.RemoveIngredient(recipeId);
      return "ingredient has been deleted";
    }
  }
}