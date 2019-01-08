using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace FunFoodServer.Infrastructure.Implementation
{
  public class JwtFactory : IJwtFactory
  {
    private readonly JwtIssuerOptions _jwtOptions;

    public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
    {
      this._jwtOptions = jwtOptions.Value;
    }

    public string GenerateEncodedToken(string userId)
    {
      var jwt = new JwtSecurityToken(
        issuer: _jwtOptions.Issuer,
        claims: GenerateClaims(userId),
        expires: _jwtOptions.Expiration,
        signingCredentials: _jwtOptions.SigningCredentials
      );

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
      return encodedJwt;
    }

    private IEnumerable<Claim> GenerateClaims(string userId)
    {
      return new Claim[]
      {
        new Claim(ClaimTypes.Name, userId)
      };
    }
  }
}
