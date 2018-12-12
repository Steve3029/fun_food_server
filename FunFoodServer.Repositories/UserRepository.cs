using System;
using System.Collections.Generic;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Domain.Specifications;
using FunFoodServer.Repositories.EntityFramework;
using FunFoodServer.Repositories.specifications;

namespace FunFoodServer.Repositories
{
  public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
  {
    public UserRepository(IRepositoryContext context)
      : base(context)
    {
    }

    public bool CheckPassword(string email, string password)
    {
      return this.Exists(new AndSpecification<User>(new EmailEqualsSpecification(email), 
        new PasswordEqualsSpecification(password)));
    }

    public bool EmailExists(string email)
    {
      return this.Exists(new EmailEqualsSpecification(email));
    }

    public User GetUserByEmail(string email)
    {
      return this.Get(new EmailEqualsSpecification(email));
    }

    public IEnumerable<User> GetUserByUserName(string userName)
    {
      return this.GetAll(new UserNameEqualsSpecification(userName));
    }
  }
}
