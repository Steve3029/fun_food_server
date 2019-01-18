using System;
using Microsoft.IdentityModel.Tokens;

namespace FunFoodServer.Infrastructure
{
  public class JwtIssuerOptions
  {
    public string Issuer { get; set; }

    public DateTime IssuedAt => DateTime.UtcNow;

    public TimeSpan ValidFor => TimeSpan.FromMinutes(120);

    public DateTime Expiration => IssuedAt.Add(ValidFor);

    public SigningCredentials SigningCredentials { get; set; }
  }
}
