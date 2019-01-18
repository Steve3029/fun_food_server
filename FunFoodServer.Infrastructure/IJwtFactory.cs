using System;
using Microsoft.Extensions.Options;

namespace FunFoodServer.Infrastructure
{
  public interface IJwtFactory
  {
    string GenerateEncodedToken(string userId);
  }
}
