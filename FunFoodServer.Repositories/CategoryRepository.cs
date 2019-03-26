using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Repositories.EntityFramework;

namespace FunFoodServer.Repositories
{
  public class CategoryRepository : EntityFrameworkRepository<Category>, ICategoryRepository
  {
    public CategoryRepository(IRepositoryContext context) 
       : base(context)
    {
    }

    public IEnumerable<Category> GetAllCategories()
    {
      return this.GetAll();
    }
  }
}
