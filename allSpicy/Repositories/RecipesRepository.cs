namespace allSpicy.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      string sql = @"
        INSERT INTO recipes
        (creatorId, title, category, instructions, imgUrl)
        VALUES
        (@creatorId, @title, @category, @instructions, @imgUrl);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }


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