using System;
namespace FunFoodServer.Domain.Repositories
{
  public interface IRepositoryContext : IUnitOfWork, IDisposable
  {
    Guid Id { get; }
  }
}
