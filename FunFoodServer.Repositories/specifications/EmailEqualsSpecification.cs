using System;
using System.Linq.Expressions;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Repositories.specifications
{
  internal class EmailEqualsSpecification : StringEqualsSpecification<User>
  {
    public EmailEqualsSpecification(string email)
      : base(email)
    {
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
      return u => u.Email == _value;
    }
  }
}
