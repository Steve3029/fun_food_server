using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;

namespace FunFoodServer.Application.Implementation
{
  public class RecipeServiceImpl : ApplicationService, IRecipeService
  {
    private readonly ICategoryRepository _categoryRepository;

    private readonly IRecipeRepository _recipeRepository;

    public RecipeServiceImpl(IRepositoryContext context,
                              ICategoryRepository categoryRepository,
                              IRecipeRepository recipeRepository)
      : base(context)
    {
      this._categoryRepository = categoryRepository;
      this._recipeRepository = recipeRepository;
    }

    public IEnumerable<Category> GetAllCategories()
    {
      return this._categoryRepository.GetAllCategories();
    }

    public void UpdateRecipe(Recipe recipe, List<Ingredient> ingredients,
                       List<Instruction> instructions)
    {
      // Rebuild Recipe from DB
      var orgRecipe = this._recipeRepository.GetCompletedRecipeByKey(recipe.Id);
      // Replace properties' value with new one
      orgRecipe.Title = recipe.Title;
      orgRecipe.Subtitle = recipe.Subtitle;
      orgRecipe.CategoryId = recipe.CategoryId;
      orgRecipe.Serving = recipe.Serving;
      orgRecipe.Description = recipe.Description;
      orgRecipe.CoverImageUrl = recipe.CoverImageUrl;

      orgRecipe.Ingredients = recipe.Ingredients;
      orgRecipe.Instructions = recipe.Instructions;
      // Register modified recipe 
      this._recipeRepository.Update(orgRecipe);
      this.Context.Commit();
    }

    public void AddRecipe(Recipe recipe, Guid ownerId,
      Ingredient[] ingredients, Instruction[] instructions)
    {
      if (recipe == null)
        throw new ArgumentNullException(nameof(recipe));

      if (ownerId == Guid.Empty)
        throw new ArgumentNullException(nameof(ownerId));

      if (ingredients == null)
        throw new ArgumentNullException(nameof(ingredients));

      if (instructions == null)
        throw new ArgumentNullException(nameof(instructions));

      this.RecipeCreatingFactory(recipe, ownerId, ingredients, instructions);

      this._recipeRepository.Add(recipe);
      this.Context.Commit();
    }

    private void RecipeCreatingFactory(Recipe recipe, Guid ownerId,
      Ingredient[] ingredients, Instruction[] instructions)
    {
      var recipeId = Guid.NewGuid();
      recipe.Id = recipeId;
      recipe.UserId = ownerId;
      for (var i = 0; i < ingredients.Length; i++)
      {
        var currentIngerident = ingredients[i];
        currentIngerident.Id = Guid.NewGuid();
        currentIngerident.RecipeId = recipeId;
        currentIngerident.OrderNumber = i + 1;
      }

      for (var j = 0; j < instructions.Length; j++)
      {
        var currentInstruction = instructions[j];
        currentInstruction.Id = Guid.NewGuid();
        currentInstruction.RecipeId = recipeId;
        currentInstruction.OrderNumber = j + 1;
      }

      recipe.Ingredients = new List<Ingredient>(ingredients);
      recipe.Instructions = new List<Instruction>(instructions);
    }
  }
}
