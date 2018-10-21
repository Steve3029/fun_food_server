using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FunFoodServer.Domain.Specifications
{
  public class AndSpecification<T> : CompositeSpecification<T>
  {

    public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
    {

    }
    public override Expression<Func<T, bool>> GetSpecification()
    {
      throw new NotImplementedException();
    }
  }
}
