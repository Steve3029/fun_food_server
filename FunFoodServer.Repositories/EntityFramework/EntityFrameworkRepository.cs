using System;
using System.Collections.Generic;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Repositories.EntityFramework
{
  public class EntityFrameworkRepository<TAggregateRoot> : Repository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
  {
    public EntityFrameworkRepository(IRepositoryContext context)
      :base(context)
    {
    }

    protected override void DoAdd(TAggregateRoot aggregateRoot)
    {
      throw new NotImplementedException();
    }

    protected override bool DoExists(ISpecification<TAggregateRoot> specification)
    {
      throw new NotImplementedException();
    }

    protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification)
    {
      throw new NotImplementedException();
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
