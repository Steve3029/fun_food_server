using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Repositories.EntityFramework
{
  public class EntityFrameworkRepository<TAggregateRoot> : Repository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
  {
    private readonly IEntityFrameworkRepositoryContext _efContext;

    public EntityFrameworkRepository(IRepositoryContext context)
      :base(context)
    {
      if (context is IEntityFrameworkRepositoryContext)
      {
        this._efContext = context as IEntityFrameworkRepositoryContext;
      }
    }

    private MemberExpression GetMemberInfo(LambdaExpression lambda)
    {
      if (lambda == null)
        throw new ArgumentNullException(nameof(lambda));

      MemberExpression memberExp = null;

      if (lambda.Body.NodeType == ExpressionType.Convert)
      {
        memberExp = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
      } 
      else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
      {
        memberExp = lambda.Body as MemberExpression;
      }

      if (lambda == null)
        throw new ArgumentException(nameof(lambda));

      return memberExp;
    }

    private string GetEagerLoadingProperty(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
    {
      MemberExpression memberExpression = this.GetMemberInfo(eagerLoadingProperty);
      var propertyName = memberExpression.Member.Name;
      return propertyName;
    }

    protected override void DoAdd(TAggregateRoot aggregateRoot)
    {
      this._efContext.RegisterNew<TAggregateRoot>(aggregateRoot);
    }

    protected override bool DoExists(ISpecification<TAggregateRoot> specification)
    {
      var count = this._efContext.Context.Set<TAggregateRoot>().Count(specification.IsSatisfiedBy);
      return count != 0;
    }

    protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification)
    {
      return this._efContext.Context.Set<TAggregateRoot>().FirstOrDefault(specification.IsSatisfiedBy);
    }

    protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      throw new NotImplementedException();
    }

    protected override TAggregateRoot DoGet(ISpecification<TAggregateRoot> specification)
    {
      throw new NotImplementedException();
    }

    protected override TAggregateRoot DoGet(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      throw new NotImplementedException();
    }

    protected override TAggregateRoot DoGetByKey(Guid Id)
    {
      throw new NotImplementedException();
    }

    protected override void DoRemove(TAggregateRoot aggregate)
    {
      throw new NotImplementedException();
    }

    protected override void DoUpdate(TAggregateRoot aggregate)
    {
      throw new NotImplementedException();
    }
  }
}
