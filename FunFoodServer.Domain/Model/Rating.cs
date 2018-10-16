using System;
namespace FunFoodServer.Domain.Model
{
  public class Rating
  {
    public Guid RecipeId
    {
      get;
      set;
    }

    public Guid UserId
    {
      get;
      set;
    }

    public int Scores
    {
      get;
      set;
    }
  }
}
