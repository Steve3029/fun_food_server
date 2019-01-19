using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;

namespace FunFoodServer.Domain.Repositories
{
  public interface IUserRepository : IRepository<User>
  {
    /// <summary>
    /// check if the given email address is exist.
    /// </summary>
    /// <returns><c>true</c>, if the email was exist, <c>false</c> otherwise.</returns>
    /// <param name="email">Email Address</param>
    bool UserExists(string email);

    /// <summary>
    /// Gets the user by the given email.
    /// </summary>
    /// <returns>The user.</returns>
    /// <param name="email">Email.</param>
    User GetUserByEmail(string email);
  }
}
