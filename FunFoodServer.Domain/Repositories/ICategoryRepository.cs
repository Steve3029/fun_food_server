using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Domain.Repositories
{
  public interface ICategoryRepository : IRepository<Category>
  {
    IEnumerable<Category> GetAllCategories();
  }
}
