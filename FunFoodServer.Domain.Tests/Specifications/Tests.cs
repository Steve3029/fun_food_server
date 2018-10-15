using System;
using FunFoodServer.Domain.Model;
using Xunit;

namespace FunFoodServer.Domain.Tests.Specifications
{
  public class Tests
  {
    [Fact]
    public void CompositeTest()
    {
      var category = new Category() { Id = Guid.NewGuid(), Name = "side" };
      var recipe = new Recipe() { Id = Guid.NewGuid(), Title = "fried eggs", Category = category };
      var titleSpecification = new TitleSpecification("egg");
      var categorySpecification = new CategorySpecification("side");

      var composed = titleSpecification.And(categorySpecification);
      bool isSatisfiedBy = composed.IsSatisfiedBy(recipe);

      Assert.True(isSatisfiedBy);
    }
  }
}
