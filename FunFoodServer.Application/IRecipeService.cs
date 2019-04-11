using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Application
{
  public interface IRecipeService
  {
    // Get all categories as dictionary for recipe form
    IEnumerable<Category> GetAllCategories();
    // Add new recipe
    void AddRecipe(Recipe recipe, Guid ownerId, 
      Ingredient[] ingeridents, Instruction[] instructions);
    // Update content of an existed recipe
    void UpdateRecipe(Recipe recipe, List<Ingredient> ingredients, 
                       List<Instruction> instructions);
  }
}
