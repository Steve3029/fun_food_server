using System;
using FunFoodServer.Application.Model;
namespace FunFoodServer.Application
{
  public interface IAuthenticateService
  {
    Guid Register(RegisterModel registerModel);

    AccountModel Login(LoginModel loginModel);
  }
}
