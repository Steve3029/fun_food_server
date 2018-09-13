using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain
{
    interface IEntity
    {
      Guid Id { get; }
    }
}
