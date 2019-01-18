//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;

//namespace FunFoodServer.Infrastructure
//{
//  public static class AuthenticateUtils
//  {

//    public static string GenerateTokenForUser(string ClaimValue, string Secret, string ClaimType = ClaimTypes.Name)
//    {
//      // generating token for user based on related data of user, like name, id
//      var tokenHandler = new JwtSecurityTokenHandler();
//      var key = Encoding.UTF8.GetBytes(Secret);
//      var tokenDescriptor = new SecurityTokenDescriptor()
//      {
//        Subject = new ClaimsIdentity(new Claim[]
//        {
//          new Claim(ClaimType, ClaimValue)
//        }),
//        Expires = DateTime.UtcNow.AddDays(3),
//        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//      };
//      var token = tokenHandler.CreateToken(tokenDescriptor);
//      return tokenHandler.WriteToken(token);
//    }



//  }
//}
