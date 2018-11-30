﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using FunFoodServer.Domain.Specifications;

namespace FunFoodServer.Domain.Repositories
{
  public interface IRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
  {
    IRepositoryContext Context { get; }
    // add a new aggregate root
    void Add(TAggregateRoot aggregateRoot);
    // get a aggregate root by its primary key
    TAggregateRoot GetByKey(Guid key);
    // get all aggregate roots from repository
    IEnumerable<TAggregateRoot> GetAll();
    // get all aggregate roots from repository with paging enable
    IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize);
    // get all aggregates from repository with sortable
    IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
    // get all aggregate roots for a page from repository using specific sorting predicate and order
    IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
    // get all aggregate roots that match the given specification
    IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification);
    // get all aggregate roots for the specified page that match the given specification
    IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize);
    // get all aggregate roots that were sorted by using given sorting predicate and sort and match the given specification
    IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
    // get all aggregate roots for a specified page that match the given specification and were sorted by using the given sorting predicate and sort order
    IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
    // 
  }
}
