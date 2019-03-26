using System;
using FunFoodServer.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunFoodServer.WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/v1/[controller]")]
  public class RecipeController : ControllerBase
  {
    private readonly ICategoryRepository _catetoryRepository;

    public RecipeController(ICategoryRepository categoryRepository)
    {
      this._catetoryRepository = categoryRepository;
    }

    // Get: api/v1/recipe/categories
    [HttpGet("categories")]
    public IActionResult GetRecipeCategories()
    {
      var categoryList = this._catetoryRepository.GetAllCategories();
      if(categoryList == null)
      {
        return Ok(null);
      }

      return Ok(categoryList);
    }
  }
}
