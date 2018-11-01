using System;
using System.Linq.Expressions;

namespace FunFoodServer.Domain.Specifications
{
  public class OrSpecification<T> : CompositeSpecification<T>
  {
    public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
    {
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
      var paramExpr = Expression.Parameter(typeof(T));
      var exprBody = Expression.OrElse(Left.ToExpression().Body, Right.ToExpression().Body);
      exprBody = (BinaryExpression)new RebindParameter(paramExpr).Visit(exprBody);
      var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

      return finalExpr;
    }
  }
}
