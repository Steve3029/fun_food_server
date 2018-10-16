using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunFoodServer.Domain.Model
{
  public class Recipe : AggregateRoot
  {
    public string Title { set; get; }

    public string BriefDesc { set; get; }

    public Category Category { set; get; }

    public string Description { get; set; }

    public string CoverImageUrl { get; set; }

    public int Serving { get; set; }

    public Guid UserId { get; set; }

    public User User { set; get; }

    public ICollection<Ingredient> Ingredients { get; set; }

    public ICollection<Instruction> Instructions { get; set; }

    public ICollection<Rating> Ratings { get; set; }

    public ICollection<Favorite> Favorites { get; set; }

    public DateTime PostDate { get; set; }
  }
}
