namespace allSpicy.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth;

    public RecipesController(RecipesService recipesService, Auth0Provider auth)
    {
      _recipesService = recipesService;
      _auth = auth;
    }

    [HttpGet]
    async public Task<ActionResult<List<Recipe>>> Find()
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        List<Recipe> recipes = _recipesService.Get(userInfo?.Id);
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}