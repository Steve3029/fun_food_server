﻿using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace FunFoodServer.Infrastructure
{
  public static class PasswordHasher
  {
    public static string HashPassword(string password)
    {
      if (string.IsNullOrWhiteSpace(password))
        throw new ArgumentNullException(nameof(password));
      var salt = GenerateSalt(16);
      var bytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);
      var saltLiteral = Convert.ToBase64String(salt);
      var hashedPassword = Convert.ToBase64String(bytes);
      return $"{ saltLiteral }:{ hashedPassword }";
    }

    public static bool VerifyHashedPassword(string password, string hashedPassword, string salt)
    {
      var byteSalt = Convert.FromBase64String(salt);
      var bytes = KeyDerivation.Pbkdf2(password, byteSalt, KeyDerivationPrf.HMACSHA512, 10000, 16);
      var passwordForVerify = Convert.ToBase64String(bytes);
      return hashedPassword.Equals(passwordForVerify);
    }

    private static byte[] GenerateSalt(int length)
    {
      var salt = new byte[length];
      using (var random = RandomNumberGenerator.Create())
      {
        random.GetBytes(salt);
      }
      return salt;
    }
  }
}