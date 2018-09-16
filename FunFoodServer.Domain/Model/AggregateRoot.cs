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
        IAggregateRoot castObj = obj as IAggregateRoot;
        if (castObj == null)
          return false;
        return castObj.Id == castObj.Id;
      }

      public override int GetHashCode()
      {
        return this.Id.GetHashCode();
      }
  }
}
