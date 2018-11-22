using FunFoodServer.Domain;

namespace FunFoodServer.Infrastructure
{
  public interface IUnitOfWork
  {

    void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot;

    void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot;


    void RegisterDelete<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot;

  }
}
