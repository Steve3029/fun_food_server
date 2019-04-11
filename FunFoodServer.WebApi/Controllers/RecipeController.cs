using System;
using System.Security.Claims;
using AutoMapper;
using FunFoodServer.Application;
using FunFoodServer.Domain.Model;
using FunFoodServer.WebApi.DTOs;
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

    private readonly IMapper _mapper;

    public RecipeController(IRecipeService recipeService, IMapper mapper)
    {
      this._recipeService = recipeService;
      this._mapper = mapper;
    }

    // Get: api/v1/recipe/categories
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

    // Post: api/v1/recipe/add
    [HttpPost("add")]
    public IActionResult AddRecipe(RecipeDTO recipeDTO)
    {
      var ownerIdStr = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
      try
      {
        var recipe = this._mapper.Map<Recipe>(recipeDTO);
        var ingredients = this._mapper.Map<Ingredient[]>(recipeDTO.Ingredients);
        var instructions = this._mapper.Map<Instruction[]>(recipeDTO.CookSteps);
        this._recipeService.AddRecipe(recipe, Guid.Parse(ownerIdStr), 
          ingredients, instructions);
        return Ok();
      }
      catch (ArgumentNullException ex)
      {
        return BadRequest($"{ex.Message} is null.");
      }
      catch (Exception ox)
      {
        return BadRequest(ox.Message);
      }
    }
  }
}
