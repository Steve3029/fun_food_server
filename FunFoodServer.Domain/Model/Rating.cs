﻿using System;
namespace FunFoodServer.Domain.Model
{
  public class Rating
  {
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public int Scores { get; set; }

    public DateTime RateDate { set; get; }
  }
}
