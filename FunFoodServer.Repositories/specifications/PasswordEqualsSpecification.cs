using System;
using System.Linq.Expressions;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Repositories.specifications
{
  internal class PasswordEqualsSpecification : StringEqualsSpecification<User>
  {
    public PasswordEqualsSpecification(string password)
      : base(password)
    {
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
      return u => u.Password == _value;
    }
  }
}
