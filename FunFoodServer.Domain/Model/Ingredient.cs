﻿using System;

namespace FunFoodServer.Domain.Model
{
  public class Ingredient : IEntity
  {
    public Guid Id { get; set; }

    public int OrderNumber { set; get; }

    public string Name { set; get; }

    public string Unit { set; get; }

    public Guid RecipeId { set; get; }

    public Recipe Recipe { get; set; }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (ReferenceEquals(this, obj))
        return true;
      if (!(obj is Ingredient other))
        return false;
      return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode() ^
             this.OrderNumber.GetHashCode() ^
             this.Name.GetHashCode() ^
             this.Unit.GetHashCode() ^ 
             this.RecipeId.GetHashCode();
    }

  }
}
