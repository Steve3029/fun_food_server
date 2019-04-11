using System;
namespace FunFoodServer.WebApi.DTOs
{
  public class IngredientDTO
  {
    public int OrderNumber { get; set; }

    public string Name { get; set; }

    public string Quantity { get; set; }
  }
}
