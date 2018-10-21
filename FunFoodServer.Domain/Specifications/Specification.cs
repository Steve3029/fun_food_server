using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain.Specifications
{
  public abstract class Specification<T> : ISpecification<T>
  {
    public ISpecification<T> And(ISpecification<T> other)
    {
      return new AndSpcification(other);
    }

    public ISpecification<T> AndNot(ISpecification<T> other)
    {
      throw new NotImplementedException();
    }

    public abstract System.Linq.Expressions.Expression<Func<T, bool>> GetSpecification();

    public bool IsSatisfiedBy(T obj)
    {
      throw new NotImplementedException();
    }

    public ISpecification<T> Not()
    {
      throw new NotImplementedException();
    }

    public ISpecification<T> Or(ISpecification<T> other)
    {
      throw new NotImplementedException();
    }
  }
}
