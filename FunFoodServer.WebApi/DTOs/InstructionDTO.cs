using System;
namespace FunFoodServer.WebApi.DTOs
{
  public class InstructionDTO
  {
    public int OrderNumber { get; set; }

    public string ImageUrl { get; set; }

    public string Description { get; set; }
  }
}
