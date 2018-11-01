using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain.Model
{
    public abstract class AggregateRoot : IAggregateRoot
    {
      public Guid Id { set; get; }

      public override bool Equals(object obj)
      {
        if (obj == null)
          return false;
        if (ReferenceEquals(this, obj))
          return true;
        if (!(obj is IAggregateRoot castObj))
          return false;
        return castObj.Id == Id;
      }

      public override int GetHashCode()
      {
        return this.Id.GetHashCode();
      }
  }
}
