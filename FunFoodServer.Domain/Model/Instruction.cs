using System;

namespace FunFoodServer.Domain.Model
{
  public class Instruction : IEntity
  {
    public Guid Id { get; set; }

    public int Index { set; get; }

    public string ImageUrl { set; get; }

    public string Description { set; get; }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (ReferenceEquals(this, obj))
        return true;
      if (!(obj is Instruction other))
        return false;
      return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode() ^
             this.Index.GetHashCode() ^
             this.ImageUrl.GetHashCode() ^
             this.Description.GetHashCode();
    }

  }
}
