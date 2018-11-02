using System;

namespace FunFoodServer.Domain.Model
{
  public class Instruction : IEntity
  {
    public Guid Id { get; set; }

    public int OrderNumber { set; get; }

    public string ImageUrl { set; get; }

    public string Description { set; get; }

    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }

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
             this.OrderNumber.GetHashCode() ^
             this.ImageUrl.GetHashCode() ^
             this.Description.GetHashCode() ^
             this.RecipeId.GetHashCode();
    }

  }
}
