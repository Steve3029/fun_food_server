using System;
using System.Linq.Expressions;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Repositories.specifications
{
  public class GetEntityByKeySpecification<T> : Specification<T>
    where T : class, IEntity
  {
    private readonly Guid _id;

    public GetEntityByKeySpecification(Guid key)
    {
      this._id = key;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
      return T => T.Id == this._id;
    }
  }
}
