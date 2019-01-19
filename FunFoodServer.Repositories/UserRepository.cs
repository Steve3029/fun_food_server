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

    public bool UserExists(string email)
    {
      return this.Exists(new EmailEqualsSpecification(email));
    }

    public User GetUserByEmail(string email)
    {
      return this.Get(new EmailEqualsSpecification(email));
    }
  }
}
