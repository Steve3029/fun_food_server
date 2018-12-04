using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Domain.Repositories
{
  public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
  {
    private readonly IRepositoryContext _context;

    public Repository(IRepositoryContext context)
    {
      this._context = context;
    }
    // Adds an aggregate root to repo
    protected abstract void DoAdd(TAggregateRoot aggregateRoot);
    // Gets an aggregate root from repo by a given key
    protected abstract TAggregateRoot DoGetByKey(Guid Id);
    // Gets all aggregate roots from repo
    protected virtual IEnumerable<TAggregateRoot> DoGetAll()
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, pageNumber, pageSize);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumnber, int pageSize)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, pageNumnber, pageSize);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification)
    {
      return DoGetAll(specification, null, SortOrder.Unspecified);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize)
    {
      return DoGetAll(specification, null, SortOrder.Unspecified, pageNumber, pageSize);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, eagerLoadingProperties);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, pageNumber, pageSize, eagerLoadingProperties);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, eagerLoadingProperties);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoGetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, eagerLoadingProperties);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoGetAll(specification, null, SortOrder.Unspecified, eagerLoadingProperties);
    }

    protected virtual IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoGetAll(specification, null, SortOrder.Unspecified, pageNumber, pageSize, eagerLoadingProperties);
    }

    protected abstract IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

    protected abstract IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);

    protected abstract IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

    protected abstract IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

  }
}
