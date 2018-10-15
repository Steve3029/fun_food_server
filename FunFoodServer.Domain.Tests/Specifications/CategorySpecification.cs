using System;
using System.Linq.Expressions;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Domain.Tests.Specifications
{

  public class CategorySpecification : Specification<Recipe>
  {
    private readonly string _category;
    public CategorySpecification(string category)
    {
      _category = category;
    }

    public override Expression<Func<Recipe, bool>> ToExpression()
    {
      return Recipe => Recipe.Category.Name == _category;
    }
  }
}
