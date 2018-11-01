using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunFoodServer.Domain.Model
{
  public class Recipe : AggregateRoot
  {
    public string Title { set; get; }

    public string Subtitle { set; get; }

    public string Description { get; set; }

    public string CoverImageUrl { get; set; }

    public int Serving { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; }

    public ICollection<Instruction> Instructions { get; set; }

    public ICollection<Rating> Ratings { get; set; }

    public ICollection<Favorite> Favorites { get; set; }

    public DateTime CreateDate { get; set; }

  }
}
