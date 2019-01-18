
using System;
using System.Collections.Generic;

namespace FunFoodServer.Domain.Model
{
  public class User : AggregateRoot
  {

    public User()
    {
      Favorites = new HashSet<Favorite>();
      Recipes = new HashSet<Recipe>();
      RecipeRatings = new HashSet<RecipeRating>();
    }

    #region Properties

    public string Email { set; get; }

    public string PasswordHash { set; get; }

    public string PasswordSalt { get; set; }

    public DateTime CreatedDate { get; set; }

    public UserProfile UserProfile { get; set; }

    public ICollection<Recipe> Recipes { set; get; }

    public ICollection<Favorite> Favorites { get; set; }

    public ICollection<RecipeRating> RecipeRatings { get; set; }

    #endregion

    #region Public methods

    #endregion
  }
}
