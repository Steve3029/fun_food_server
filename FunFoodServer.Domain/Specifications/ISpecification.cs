using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FunFoodServer.Domain.Specifications
{
  public interface ISpecification<T>
  {
    // Returns a bool value that indicates whether 
    // the specification is satisfied by the given object. 
    bool IsSatisfiedBy(T obj);

    // Gets the LINQ expression which represents the current specification.
    Expression<Func<T, bool>> GetSpecification();

    // Combines the current specification instance with another one 
    // and returns the combined spcification that indicates both the 
    // current specification and another one must be satisfied by the given object.
    ISpecification<T> And(ISpecification<T> other);

    // Combines the current specification instance with another one 
    // and returns the combined spcification that represents that either the 
    // current specification or another one should be satisfied by the given object.
    ISpecification<T> Or(ISpecification<T> other);

    // Combines the current specification instance with another one 
    // and returns the combined spcification that represents that the 
    // current specification should be satisfied by the given object 
    // but another one should not.
    ISpecification<T> AndNot(ISpecification<T> other);

    // Reverses the current specification instance and returns a specification 
    // with represents the semantics opposite to the current specification.
    ISpecification<T> Not();
  }
}
