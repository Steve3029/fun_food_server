﻿
using System;
using System.Collections.Generic;

namespace FunFoodServer.Domain.Model
{
  public class User : AggregateRoot
  {
    #region Properties

    public UserProfile Profile { get; set; }

    public string UserName { set; get; }

    public string Password { set; get; }

    public string Email { set; get; }

    public string PhotoUrl { get; set; }

    public ICollection<Recipe> Recipes { set; get; }

    public ICollection<Favorite> Favorites { get; set; }

    #endregion

    #region Public methods

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (ReferenceEquals(obj, this))
        return true;
      if (!(obj is UserProfile other))
        return false;
      return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode() ^
             this.Profile.GetHashCode() ^
             this.UserName.GetHashCode() ^
             this.Email.GetHashCode() ^
             this.Password.GetHashCode() ^
             this.PhotoUrl.GetHashCode();
    }
    #endregion
  }
}
