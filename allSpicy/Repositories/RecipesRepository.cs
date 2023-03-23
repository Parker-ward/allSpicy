namespace allSpicy.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal List<Recipe> FindAll()
    // {
    //   string sql = @"
    //   SELECT
    //   *
    //   FROM recipes;
    //   ";
    //   List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();
    //   return recipes;
    // }

    internal List<Recipe> GetAll()
    {
      string sql = @"
      SELECT
      res.*,
      acct.*
      FROM recipes res
      JOIN accounts acct ON res.creatorId = acct.id;
      ";
      List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, prof) =>
      {
        recipe.Creator = prof;
        return recipe;
      }).ToList();
      return recipes;
    }
  }
}