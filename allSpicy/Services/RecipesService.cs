namespace allSpicy.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> Find()
    {
      List<Recipe> recipes = _repo.FindAll();
      return recipes;
    }
  }
}