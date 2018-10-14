using System;
using System.Linq.Expressions;

namespace FunFoodServer.Domain.Specifications
{
  internal class RebindParameter : ExpressionVisitor
  {
    private readonly ParameterExpression _parameter;

    internal RebindParameter(ParameterExpression parameter)
    {
      _parameter = parameter;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
      return base.VisitParameter(_parameter);
    }
  }
}
