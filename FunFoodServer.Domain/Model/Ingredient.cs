using System;

namespace FunFoodServer.Domain.Model
{
    public class Ingredient
    {
      public int Index { set; get; }

      public Guid RecipeId { set; get; }

      public Recipe Recipe { set; get; }

      public string Name { set; get; }

      public string Unit { set; get; }
      
    }
}
