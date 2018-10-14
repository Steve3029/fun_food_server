using System;
using System.Linq.Expressions;

namespace FunFoodServer.Domain.Specifications
{
  public abstract class Specification<T> : ISpecification<T>
  {
    public ISpecification<T> And(ISpecification<T> other)
    {
      return new AndSpecification<T>(this, other);
    }

    public bool IsSatisfiedBy(T entity)
    {
      Func<T, bool> predicate = ToExpression().Compile();
      return predicate.Invoke(entity);
    }

    public ISpecification<T> Or(ISpecification<T> other)
    {
      return new OrSpecification<T>(this, other);
    }

    public abstract Expression<Func<T, bool>> ToExpression();
  }
}
