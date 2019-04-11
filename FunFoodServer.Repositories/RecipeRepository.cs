using System;
using System.Linq.Expressions;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Repositories.EntityFramework;
using FunFoodServer.Repositories.specifications;

namespace FunFoodServer.Repositories
{
  public class RecipeRepository : EntityFrameworkRepository<Recipe>, IRecipeRepository
  {
    public RecipeRepository(IRepositoryContext context)
      : base(context)
    {
    }

    public Recipe GetCompletedRecipeByKey(Guid key)
    {
      if (key == null)
        throw new ArgumentNullException(nameof(key));

      var query = new GetEntityByKeySpecification<Recipe>(key);
      var eagerLoadingProperties = new Expression<Func<Recipe, dynamic>>[] { 
        r => r.Ingredients,
        r => r.Instructions,
      };
      var recipe = this.DoGet(query, eagerLoadingProperties);

      return recipe;

    }
  }
}
