using System;
using System.Linq.Expressions;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Domain.Tests.Specifications
{
  public class TitleSpecification : Specification<Recipe>
  {
    private readonly string _title;
    public TitleSpecification(string title)
    {
      _title = title;
    }

    public override Expression<Func<Recipe, bool>> ToExpression()
    {
      return Recipe => Recipe.Title.Contains(_title);
    }
  }
}
