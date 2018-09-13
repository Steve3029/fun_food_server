using System;

namespace FunFoodServer.Domain.Model
{
    public class Ingredient
    {
      public int IngredientNumber { set; get; }

      public Guid RecipeId { set; get; }

      public string Name { set; get; }

      public string Unit { set; get; }
      
    }
}
