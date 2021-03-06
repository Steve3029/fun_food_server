﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Domain.Repositories
{
  public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
  {
    private readonly IRepositoryContext _context;

    protected Repository(IRepositoryContext context)
    {
      this._context = context;
    }

    public IRepositoryContext Context
    {
      get { return _context; }
    }

    #region protected methods
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

    protected IEnumerable<TAggregateRoot> DoFindAll()
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(int pageNumber, int pageSize)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, pageNumber, pageSize);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, pageNumber, pageSize);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification)
    {
      return DoFindAll(specification, null, SortOrder.Unspecified);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize)
    {
      return DoFindAll(specification, null, SortOrder.Unspecified, pageNumber, pageSize);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, eagerLoadingProperties);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, pageNumber, pageSize, eagerLoadingProperties);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, eagerLoadingProperties);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFindAll(specification, null, SortOrder.Unspecified, eagerLoadingProperties);
    }

    protected IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, pageNumber, pageSize, eagerLoadingProperties);
    }

    protected abstract IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

    protected abstract IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);

    protected abstract IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

    protected abstract IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

    protected abstract TAggregateRoot DoGet(ISpecification<TAggregateRoot> specification);

    protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification);

    protected abstract TAggregateRoot DoGet(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

    protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

    protected abstract bool DoExists(ISpecification<TAggregateRoot> specification);

    protected abstract void DoRemove(TAggregateRoot aggregate);

    protected abstract void DoUpdate(TAggregateRoot aggregate);

    #endregion

    #region IRepository<TAggregateRoot> members

    public void Add(TAggregateRoot aggregateRoot)
    {
      this.DoAdd(aggregateRoot);
    }

    public TAggregateRoot GetByKey(Guid key)
    {
      return this.DoGetByKey(key);
    }

    public IEnumerable<TAggregateRoot> GetAll()
    {
      return this.DoGetAll();
    }

    public IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize)
    {
      return this.DoGetAll(pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      return this.DoGetAll(sortPredicate, sortOrder);
    }

    public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      return this.DoGetAll(sortPredicate, sortOrder, pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification)
    {
      return this.DoGetAll(specification);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize)
    {
      return DoGetAll(specification, pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      return this.DoGetAll(specification, sortPredicate, sortOrder);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      return this.DoGetAll(specification, sortPredicate, sortOrder, pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(pageNumber, pageSize, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(sortPredicate, sortOrder, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(specification, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumnber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(specification, pageNumnber, pageSize, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(specification, sortPredicate, sortOrder, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGetAll(specification, sortPredicate, sortOrder, pageNumber, pageSize,  eagerLoadingProperties);
    }

    public TAggregateRoot Get(ISpecification<TAggregateRoot> specification)
    {
      return this.DoGet(specification);
    }

    public TAggregateRoot Get(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoGet(specification, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(){
      return this.DoFindAll();
    }

    public IEnumerable<TAggregateRoot> FindAll(int pageNumber, int pageSize)
    {
      return this.DoFindAll(pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      return this.DoFindAll(sortPredicate, sortOrder);
    }

    public IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      return this.DoFindAll(sortPredicate, sortOrder, pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification)
    {
      return this.DoFindAll(specification);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize)
    {
      return this.DoFindAll(specification, pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
    {
      return this.DoFindAll(specification, sortPredicate, sortOrder);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
    {
      return this.DoFindAll(specification, sortPredicate, sortOrder, pageNumber, pageSize);
    }

    public IEnumerable<TAggregateRoot> FindAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(pageNumber, pageSize, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(sortPredicate, sortOrder, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(specification, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, int pageNumnber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(specification, pageNumnber, pageSize, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(specification, sortPredicate, sortOrder, eagerLoadingProperties);
    }

    public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return this.DoFindAll(specification, sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
    }

    public TAggregateRoot Find(ISpecification<TAggregateRoot> specification)
    {
      return DoFind(specification);
    }

    public TAggregateRoot Find(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
    {
      return DoFind(specification, eagerLoadingProperties);
    }

    public bool Exists(ISpecification<TAggregateRoot> specification)
    {
      return this.DoExists(specification);
    }

    public void Remove(TAggregateRoot aggregateRoot)
    {
      this.DoRemove(aggregateRoot);
    }

    public void Update(TAggregateRoot aggregateRoot)
    {
      this.DoUpdate(aggregateRoot);
    }


    #endregion
  }
}
