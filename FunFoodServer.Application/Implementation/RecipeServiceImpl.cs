using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;

namespace FunFoodServer.Application.Implementation
{
  public class RecipeServiceImpl : ApplicationService, IRecipeService
  {
    private readonly ICategoryRepository _categoryRepository;

    public RecipeServiceImpl(IRepositoryContext context, ICategoryRepository categoryRepository)
      : base(context)
    {
      this._categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetAllCategories()
    {
      return this._categoryRepository.GetAllCategories();
    }
  }
}
