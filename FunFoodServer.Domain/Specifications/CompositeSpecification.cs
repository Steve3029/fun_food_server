using System;
namespace FunFoodServer.Domain.Specifications
{
  public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T>
  {
    protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
    {
      this.Left = left;
      this.Right = right;
    }

    public ISpecification<T> Left
    {
      get;
    }

    public ISpecification<T> Right
    {
      get;
    }
  }
}
