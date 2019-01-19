using System;
namespace FunFoodServer.WebApi.DTOs
{
  public class UserDTO
  {
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string PassWord { get; set; }
  }
}
