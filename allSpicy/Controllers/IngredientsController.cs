namespace allSpicy.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientService;
    private readonly Auth0Provider _auth;

    public IngredientsController(IngredientsService ingredientService, Auth0Provider auth)
    {
      _ingredientService = ingredientService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Ingredient ingredient = _ingredientService.CreateIngredient(ingredientData);
        ingredient.Creator = userInfo;
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}