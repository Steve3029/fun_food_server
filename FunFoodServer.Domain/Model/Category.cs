
using System.Collections.Generic;

namespace FunFoodServer.Domain.Model
{
    public class Category : AggregateRoot
    {
      public string Name { set; get; }

      public string Description { set; get; }

      public List<Recipe> Recipes { get; set; }

      public override string ToString()
      {
        return this.Name;
      }
    }
}
