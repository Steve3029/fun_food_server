using System;
namespace FunFoodServer.Domain.Repositories
{
  public interface IUnitOfWork
  {
    void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot;

    void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot;


    void RegisterDelete<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot;

    void Commit();

    bool Committed { get; }

    void Rollback();
  }
}
