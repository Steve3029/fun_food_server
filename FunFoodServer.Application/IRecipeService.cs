using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Application
{
  public interface IRecipeService
  {
    IEnumerable<Category> GetAllCategories();
  }
}
