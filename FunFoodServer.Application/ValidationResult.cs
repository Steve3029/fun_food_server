using System;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Application
{
  public class ValidationResult
  {
    public bool Succeeded { get; private set; }

    public User User { get; set; }

    public ValidationResult(bool isSucceed, User user)
    {
      this.Succeeded = isSucceed;
      this.User = user;
    }
  }
}
