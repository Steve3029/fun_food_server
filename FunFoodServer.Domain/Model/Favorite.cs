using System;
namespace FunFoodServer.Domain.Model
{
  public class Favorite
  {
    public Guid UserId { get; set; }

    public Guid RecipeId { set; get; }

    public Recipe Recipe { set; get; }

    public User User { get; set; }
  }
}
