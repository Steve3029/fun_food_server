using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain.Specifications
{
  public interface ICompositeSpecification<T> : ISpecification<T>
  {
    // Gets the left side specification
    ISpecification<T> Left { get; }

    // Gets the right side specification
    ISpecification<T> Right { get; }
  }
}
