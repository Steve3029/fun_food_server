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
    bool EmailExists(string email);

    /// <summary>
    /// Checks the given user's password
    /// </summary>
    /// <returns><c>true</c>, if password was identical, <c>false</c> otherwise.</returns>
    /// <param name="email">Email.</param>
    /// <param name="password">Password.</param>
    bool CheckPassword(string email, string password);

    /// <summary>
    /// Gets users by given user name.
    /// </summary>
    /// <returns>The users who has the given userName.</returns>
    /// <param name="userName">User name.</param>
    IEnumerable<User> GetUserByUserName(string userName);

    /// <summary>
    /// Gets the user by the given email.
    /// </summary>
    /// <returns>The user.</returns>
    /// <param name="email">Email.</param>
    User GetUserByEmail(string email);
  }
}
