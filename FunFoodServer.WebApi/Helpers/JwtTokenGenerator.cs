using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FunFoodServer.Domain.Model;
using Microsoft.IdentityModel.Tokens;

namespace FunFoodServer.WebApi.Helpers
{
  internal static class JwtTokenGenerator
  {
    public static string GenerateToken(User user, string issuer, string secret)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(secret);
      var claims = new Claim[]
      {
        new Claim(ClaimTypes.Name, user.Id.ToString())
      };

      var tokenDescriptor = new SecurityTokenDescriptor()
      {
        Issuer = issuer,
        Subject = new System.Security.Claims.ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddMinutes(120),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return tokenString;
    }
  }
}
