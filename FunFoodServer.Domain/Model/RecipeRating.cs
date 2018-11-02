using System;
namespace FunFoodServer.Domain.Model
{
  public class RecipeRating
  {
    public Guid RecipeId { get; set; }

    public Guid UserId { get; set; }

    public int Scores { get; set; }

    public Recipe Recipe { get; set; }

    public User User { get; set; }

    public DateTime RateDate { set; get; }
  }
}
