namespace allSpicy.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
      _recipesService = recipesService;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> Find()
    {
      try
      {
        List<Recipe> recipes = _recipesService.Find();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}