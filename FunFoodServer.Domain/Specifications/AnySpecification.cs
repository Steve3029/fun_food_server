using System;
using System.Linq.Expressions;

namespace FunFoodServer.Domain.Specifications
{
  public class AnySpecification<T> : Specification<T>
  {
    public override Expression<Func<T, bool>> ToExpression()
    {
      return p => true;
    }
  }
}
