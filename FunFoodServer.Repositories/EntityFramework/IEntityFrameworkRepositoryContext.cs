using System;
using FunFoodServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FunFoodServer.Repositories.EntityFramework
{
  public interface IEntityFrameworkRepositoryContext : IRepositoryContext
  {
    DbContext Context { get; }
  }
}
