using System;
using FunFoodServer.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunFoodServer.WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/v1/[controller]")]
  public class RecipeController : ControllerBase
  {
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
      this._recipeService = recipeService;
    }

    // Get: api/v1/recipe/categories
    [AllowAnonymous]
    [HttpGet("categories")]
    public IActionResult GetAllCategories()
    {
      try
      {
        var categoryList = this._recipeService.GetAllCategories();
        if (categoryList == null)
        {
          return Ok(null);
        }

        return Ok(categoryList);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
