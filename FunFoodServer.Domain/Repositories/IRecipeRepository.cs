using System;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Domain.Repositories
{
  public interface IRecipeRepository : IRepository<Recipe>
  {
    Recipe GetCompletedRecipeByKey(Guid key);
  }
}
