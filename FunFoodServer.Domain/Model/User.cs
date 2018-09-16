using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain.Model
{
    public class User : AggregateRoot
    {
      public Guid AccountId { get; set; }

      public Account Account { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public int Gender { get; set; }

      public DateTime Birthday { get; set; }

      public string Location { get; set; }

      public string GooglePlus { get; set; }

      public string Twitter { get; set; }

      public string Facebook { get; set; }

      public string Youtube { get; set; }
    }
}
