using System;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.WebApi.DTOs
{
  public class RecipeDTO
  {
    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Description { get; set; }

    public string CoverImage { get; set; }

    public Guid CategoryId { get; set; }

    public int Serve { get; set; }

    public IngredientDTO[] Ingredients { get; set; }

    public InstructionDTO[] Instructions { get; set; }
  }
}
