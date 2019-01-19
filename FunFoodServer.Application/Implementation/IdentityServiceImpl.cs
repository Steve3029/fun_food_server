using System;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Infrastructure;

namespace FunFoodServer.Application.Implementation
{
  public class IdentityServiceImpl : ApplicationService, IIdentityService
  {
    private readonly IUserRepository _userRepository;

    public IdentityServiceImpl(IRepositoryContext context, IUserRepository userRepository)
      : base(context)
    {
      this._userRepository = userRepository;
    }

    public ValidationResult ValidationPassword(string email, string password)
    {
      if (string.IsNullOrEmpty(email))
        throw new ArgumentNullException(nameof(email));

      if (string.IsNullOrEmpty(password))
        throw new ArgumentNullException(nameof(password));

      if (!_userRepository.UserExists(email))
        return new ValidationResult(false, null);

      var user = _userRepository.GetUserByEmail(email);
      if (user == null)
        throw new DomainException("User with the email of '{0}' does not exist.", email);
      // varify password
      var passwordIsMatch = PasswordHasher.VerifyHashedPassword(password, user.PasswordHash, user.PasswordSalt);
      if (!passwordIsMatch)
        return new ValidationResult(false, null);

      return new ValidationResult(true, user);
    }

    public Guid SignUp(User newUser, string password)
    {
      if (newUser == null)
        throw new ArgumentNullException(nameof(newUser));

      if (string.IsNullOrWhiteSpace(newUser.Email))
        throw new ArgumentNullException(nameof(newUser.Email));

      if (string.IsNullOrWhiteSpace(password))
        throw new ArgumentNullException(nameof(password));

      bool userIsExist = _userRepository.UserExists(newUser.Email);
      if (userIsExist)
        throw new DomainException("User with the email of '{0}' already exists. ", newUser.Email);
      
      var hashedPasswordAndSalt = PasswordHasher.HashPassword(password).Split(":");
      newUser.Id = Guid.NewGuid();
      newUser.PasswordSalt = hashedPasswordAndSalt[0];
      newUser.PasswordHash = hashedPasswordAndSalt[1];
      newUser.CreateUserProfile();
      _userRepository.Add(newUser);
      Context.Commit();
      return newUser.Id;
    }
  }
}
