using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunFoodServer.Domain.Model
{
  public class Recipe : AggregateRoot
  {
    public Guid UserId { get; set; }

    public Guid CategoryId { get; set; }

    public string Title { set; get; }

    public string Subtitle { set; get; }

    public string Description { get; set; }

    public string CoverImageUrl { get; set; }

    public int Serving { get; set; }

    public DateTime CreatedDate { get; set; }

    public User User { get; set; }

    public Category Category { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; }

    public ICollection<Instruction> Instructions { get; set; }

    public ICollection<RecipeRating> RecipeRatings { get; set; }

    public ICollection<Favorite> Favorites { get; set; }

    public DateTime CreateDate { get; set; }

  }
}
