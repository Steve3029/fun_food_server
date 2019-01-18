using System;

// this interface will be as the type of all Entity domain objects
namespace FunFoodServer.Domain
{
    public interface IEntity
    {
      Guid Id { get; }
    }
}
