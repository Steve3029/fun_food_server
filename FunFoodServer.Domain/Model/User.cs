
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

    #endregion
  }
}
