
using System;

namespace FunFoodServer.Domain.Model
{
  public class Account : IEntity
  {
    public Guid Id { get; set; }
    public string UserName { set; get; }

    public string Password { set; get; }

    public string Email { set; get; }

    public string PhotoUrl { get; set; }
  }
}
