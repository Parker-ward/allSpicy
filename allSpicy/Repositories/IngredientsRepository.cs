namespace allSpicy.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId)
      VALUES
      (@name, @quantity, @recipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }

    internal List<Ingredient> FindByRecipe(int recipeId)
    {
      string sql = @"
      SELECT
      ing.*
      FROM ingredients ing
      WHERE ing.recipeId = @recipeId;
      ";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
      return ingredients;
    }
  }
}