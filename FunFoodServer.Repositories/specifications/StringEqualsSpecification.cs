using System;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Repositories.specifications
{
  internal abstract class StringEqualsSpecification<T> : Specification<T>
  {
    protected readonly string _value;

    protected StringEqualsSpecification(string value)
    {
      this._value = value;
    }
  }
}
