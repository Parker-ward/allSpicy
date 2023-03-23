namespace allSpicy.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      Recipe recipe = _repo.CreateRecipe(recipeData);
      return recipe;
    }

    internal Recipe EditRecipe(int id, Recipe recipeData, Account userInfo)
    {
      Recipe original = this.Find(id, userInfo.Id);
      original.Title = recipeData.Title != null ? recipeData.Title : original.Title;
      original.Category = recipeData.Category != null ? recipeData.Category : original.Category;
      original.Instructions = recipeData.Instructions != null ? recipeData.Instructions : original.Instructions;
      original.Img = recipeData.Img != null ? recipeData.Img : original.Img;
      int rowsAffected = _repo.Update(original);
      if (rowsAffected == 0) throw new Exception("could not modify");
      if (rowsAffected > 1) throw new Exception("Something went wrong");
      return original;
    }

    internal List<Recipe> Find(string userId)
    {
      List<Recipe> recipes = _repo.GetAll();
      return recipes;
    }

    internal Recipe Find(int id, string userId)
    {
      Recipe recipe = _repo.GetOne(id);
      if (recipe == null) throw new Exception("Nope");
      return recipe;
    }
  }
}