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


    internal List<Recipe> Get(string userId)
    {
      List<Recipe> recipes = _repo.GetAll();
      return recipes;
    }

    internal Recipe GetOne(int id, string userId)
    {
      Recipe recipe = _repo.GetOne(id);
      if (recipe == null) throw new Exception("Nope");
      return recipe;
    }
  }
}