
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

    public void CreateUserProfile()
    {
      UserProfile = new UserProfile
      {
        Id = Guid.NewGuid(),
        User = this,
        UserId = this.Id
      };
    }

    #region Properties

    public string UserName { set; get; }

    public string Password { set; get; }

    public string Email { set; get; }

    public string PhotoUrl { get; set; }

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
