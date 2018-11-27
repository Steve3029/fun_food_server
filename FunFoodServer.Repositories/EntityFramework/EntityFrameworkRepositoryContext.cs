﻿using System;
using System.Threading;
using FunFoodServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FunFoodServer.Repositories.EntityFramework
{
  public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameworkRepositoryContext
  {

    private readonly ThreadLocal<DbContext> _dbContext = new ThreadLocal<DbContext>(() => new FunFoodDbContext());

    public DbContext Context
    {
      get { return _dbContext.Value; }
    }

    public override void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
    {
      _dbContext.Value.Entry<TAggregateRoot>(entity).State = EntityState.Added;
      Committed = false;
    }

    public override void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
    {
      _dbContext.Value.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
      Committed = false;
    }

    public override void RegisterDelete<TAggregateRoot>(TAggregateRoot entity)
    {
      _dbContext.Value.Entry<TAggregateRoot>(entity).State = EntityState.Deleted;
      Committed = false;
    }

    public override void Commit()
    {
      if (!Committed)
      {
        _dbContext.Value.SaveChanges();
        Committed = true;
      }
    }

    public override void Rollback()
    {
      Committed = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (!Committed)
          Commit();
        _dbContext.Value.Dispose();
        _dbContext.Dispose();
        base.Dispose(disposing);
      }
    }
  }
}
