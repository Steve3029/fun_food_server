using System;
namespace FunFoodServer.Application.Model
{
  public class AccountModel
  {
    public AccountModel(string userName, Guid id, string email)
    {
      this.UserName = userName;
      this.Id = id;
      this.Email = email;
    }

    public string UserName { get; set; }

    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }
  }
}
