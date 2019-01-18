using System;
using System.Linq.Expressions;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Repositories.specifications
{
  internal class UserNameEqualsSpecification : StringEqualsSpecification<User>
  {
    public UserNameEqualsSpecification(string userName)
      : base(userName)
    {
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
      return u => u.UserName == _value;
    }
  }
}
