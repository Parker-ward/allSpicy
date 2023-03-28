namespace allSpicy.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Favorite Create(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites
      (accountId, recipeId)
      VALUES
      (@accountId, @recipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, favoriteData);
      favoriteData.Id = id;
      return favoriteData;
    }

    public Favorite FindFavorite(Favorite favoriteData)
    {
      string sql = @"
      SELECT
      *
      FROM favorites
      WHERE accountId = @accountId AND recipeId = @recipeId;
      ";
      Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
      return favorite;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId)
    {
      string sql = @"
     SELECT
      r.*,
      favs.*,
      creator.*
     FROM favorites favs
      JOIN recipes r ON favs.recipeId = r.id
      JOIN accounts creator ON r.creatorId = creator.id
      WHERE favs.accountId = @userId
     ";
      List<FavoriteRecipe> favoriteRecipes = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (r, favs, profile) =>
      {
        favs.FavoriteId = favs.Id;
        favs.Creator = profile;
        return favs;
      }, new { userId }).ToList();
      return favoriteRecipes;
    }
  }
}