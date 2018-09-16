using System;

namespace FunFoodServer.Domain.Model
{
    public class Instruction
    {
      public int Index { set; get; }

      public Guid RecipeId { set; get; }

      public string ImageUrl { set; get; }

      public string Description { set; get; }
    }
}
