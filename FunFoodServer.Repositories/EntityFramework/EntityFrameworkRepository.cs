using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

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
      var dbSet = this._efContext.Context.Set<TAggregateRoot>();
      if (eagerLoadingProperties != null && 
          eagerLoadingProperties.Length > 0)
      {
        var eagerLoadingPath = "";
        foreach (var eagerLoadingProperty in eagerLoadingProperties)
        {
          eagerLoadingPath = this.GetEagerLoadingProperty(eagerLoadingProperty);
          dbSet.Include(eagerLoadingPath);
        }
        return dbSet.FirstOrDefault(specification.IsSatisfiedBy);
      }
      else
      {
        return dbSet.FirstOrDefault(specification.IsSatisfiedBy);
      }
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      var dbQuery = this._efContext.Context.Set<TAggregateRoot>()
          .Where(specification.IsSatisfiedBy);

      if (sortPredicate != null)
      {
        switch (sortOrder)
        {
          case SortOrder.Ascending:
            return dbQuery.OrderBy(sortPredicate.Compile()).ToList();
          case SortOrder.Descending:
            return dbQuery.OrderByDescending(sortPredicate.Compile()).ToList();
          default:
            break;
        }
      }

      return dbQuery.ToList();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      if (pageNumber <= 0)
        throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "The pageNumber is one-based and should be larger than zero.");

      if (pageSize <= 0)
        throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "The pageSize is one-based and should be larger than zero.");

      var dbQuery = this._efContext.Context.Set<TAggregateRoot>()
          .Where(specification.IsSatisfiedBy);
      var skip = (pageNumber - 1) * pageSize;
      var take = pageSize;
      if (sortPredicate != null)
      {
        switch (sortOrder)
        {
          case SortOrder.Ascending:
            return dbQuery.OrderBy(sortPredicate.Compile()).Skip(skip).Take(take).ToList();
          case SortOrder.Descending:
            return dbQuery.OrderByDescending(sortPredicate.Compile()).Skip(skip).Take(take).ToList();
          default:
            break;
        }
      }
      return dbQuery.Skip(skip).Take(take).ToList();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      var dbSet = this._efContext.Context.Set<TAggregateRoot>();
      IEnumerable<TAggregateRoot> queryable = null;
      // dealing with eagerLoadingProperties
      if (eagerLoadingProperties != null &&
          eagerLoadingProperties.Length > 0)
      {
        var eagerLoadingPath = "";
        foreach (var eagerLoadingProperty in eagerLoadingProperties)
        {
          eagerLoadingPath = this.GetEagerLoadingProperty(eagerLoadingProperty);
          dbSet.Include(eagerLoadingPath);
        }
        queryable = dbSet.Where(specification.IsSatisfiedBy);
      }
      else
        queryable = dbSet.Where(specification.IsSatisfiedBy);
      // dealing with sorting
      if (sortPredicate != null)
      {
        switch (sortOrder)
        {
          case SortOrder.Ascending:
            return queryable.OrderBy(sortPredicate.Compile()).ToList();
          case SortOrder.Descending:
            return queryable.OrderByDescending(sortPredicate.Compile()).ToList();
          default:
            break;
        }
      }
      // no sorting aruguments
      return queryable.ToList();
    }

    protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      if (pageNumber <= 0)
        throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "The pageNumber is one-based and should be larger than zero.");

      if (pageSize <= 0)
        throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "The pageSize is one-based and should be larger than zero.");

      var skip = (pageNumber - 1) * pageSize;
      var take = pageSize;

      var dbSet = this._efContext.Context.Set<TAggregateRoot>();
      IEnumerable<TAggregateRoot> queryable = null;
      // dealing with eagerLoadingProperties
      if (eagerLoadingProperties != null &&
          eagerLoadingProperties.Length > 0)
      {
        var eagerLoadingPath = "";
        foreach (var eagerLoadingProperty in eagerLoadingProperties)
        {
          eagerLoadingPath = this.GetEagerLoadingProperty(eagerLoadingProperty);
          dbSet.Include(eagerLoadingPath);
        }
        queryable = dbSet.Where(specification.IsSatisfiedBy);
      }
      else
        queryable = dbSet.Where(specification.IsSatisfiedBy);
      // dealing with sorting
      if (sortPredicate != null)
      {
        switch (sortOrder)
        {
          case SortOrder.Ascending:
            return queryable.OrderBy(sortPredicate.Compile()).Skip(skip).Take(take).ToList();
          case SortOrder.Descending:
            return queryable.OrderByDescending(sortPredicate.Compile()).Skip(skip).Take(take).ToList();
          default:
            break;
        }
      }
      // no sorting arguments
      return queryable.Skip(skip).Take(take).ToList();
    }

    protected override TAggregateRoot DoGet(ISpecification<TAggregateRoot> specification)
    {
      TAggregateRoot result = this.DoFind(specification);
      if (result == null)
        throw new ArgumentException("Aggregate not found.");
      return result;
    }

    protected override TAggregateRoot DoGet(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      TAggregateRoot result = this.DoFind(specification, eagerLoadingProperties);
      if (result == null)
        throw new ArgumentException("Aggregate not found.");
      return result;
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      var results = this.DoFindAll(specification, sortPredicate, sortOrder);
      if (results == null || !results.Any())
        return null;
      return results;
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      var results = this.DoFindAll(specification, sortPredicate, sortOrder, pageNumber, pageSize);
      if (results == null || !results.Any())
        throw new ArgumentException("Aggregate not found.");
      return results;
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      var results = this.DoFindAll(specification, sortPredicate, sortOrder, eagerLoadingProperties);
      if (results == null || !results.Any())
        throw new ArgumentException("Aggregate not found.");
      return results;
    }

    protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      var results = this.DoFindAll(specification, sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
      if (results == null || !results.Any())
        throw new ArgumentException("Aggregate not found.");
      return results;
    }

    protected override TAggregateRoot DoGetByKey(Guid Id)
    {
      return this._efContext.Context.Set<TAggregateRoot>().Where(p => p.Id == Id).First();
    }

    protected override void DoRemove(TAggregateRoot aggregate)
    {
      this._efContext.RegisterDelete<TAggregateRoot>(aggregate);
    }

    protected override void DoUpdate(TAggregateRoot aggregate)
    {
      this._efContext.RegisterModified<TAggregateRoot>(aggregate);
    }
  }
}
