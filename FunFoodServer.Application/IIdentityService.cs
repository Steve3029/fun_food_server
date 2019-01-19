using System;
using FunFoodServer.Domain.Model;
namespace FunFoodServer.Application
{
  public interface IIdentityService
  {
    Guid SignUp(User newUser, string password);

    ValidationResult ValidationPassword(string email, string password);
  }
}
