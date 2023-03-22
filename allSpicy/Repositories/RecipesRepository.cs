namespace allSpicy.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Recipe> FindAll()
    {
      string sql = @"
      SELECT
      *
      FROM recipes;
      ";
      List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();
      return recipes;
    }
  }
}