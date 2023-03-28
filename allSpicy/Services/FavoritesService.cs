namespace allSpicy.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
      Favorite foundFavorite = _repo.FindFavorite(favoriteData);
      if (foundFavorite != null) throw new Exception("you have already favorited this recipe");
      Favorite favorite = _repo.Create(favoriteData);
      return favorite;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId)
    {
      List<FavoriteRecipe> favoriteRecipes = _repo.GetAccountFavorites(userId);
      return favoriteRecipes;
    }

    internal string RemoveRecipeFav(int id, string userId)
    {
      Favorite favorite = _repo.GetOne(id);
      if (favorite == null) throw new Exception($"no fav at this id: {id}");
      if (favorite.AccountId != userId) throw new Exception("Not your fav bruh");
      _repo.Remove(id);
      return "you left, now you eat ALONE!";
    }
  }
}