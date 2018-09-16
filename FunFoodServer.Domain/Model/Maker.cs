
using System;

namespace FunFoodServer.Domain.Model
{
    public class Maker : IEntity
    {
      public Guid Id { get; set; }

      public string UserName { get; set; }

      public string PhotoUrl { get; set; }
  
    }
}
