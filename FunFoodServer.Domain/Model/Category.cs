
using System.Collections.Generic;

namespace FunFoodServer.Domain.Model
{
    public class Category : AggregateRoot
    {
      public Category()
      {
        Recipes = new HashSet<Recipe>();
      }

      public string Name { set; get; }

      public string Description { set; get; }

      public ICollection<Recipe> Recipes { get; set; }

      public override string ToString()
      {
        return this.Name;
      }
    }
}
