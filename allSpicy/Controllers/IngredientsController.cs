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
        ingredientData.CreatorId = userInfo.Id;
        Ingredient ingredient = _ingredientService.CreateIngredient(ingredientData);
        ingredient.Creator = userInfo;
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    async public Task<ActionResult<String>> RemoveIngredient(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        string message = _ingredientService.removeIngredient(id, userInfo.Id);
        return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}