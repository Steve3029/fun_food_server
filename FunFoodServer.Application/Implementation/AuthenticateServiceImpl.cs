using System;
using AutoMapper;
using FunFoodServer.Application.Model;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace FunFoodServer.Application.Implementation
{
  public class AuthenticateServiceImpl : ApplicationService, IAuthenticateService
  {
    private readonly IUserRepository _userRepository;

    private readonly IPasswordHasher<User> _hasher;

    private readonly IJwtFactory _jwtFactory;

    public AuthenticateServiceImpl(IRepositoryContext context, IUserRepository userRepository, 
      IPasswordHasher<User> hasher, IJwtFactory jwtFactory)
      : base(context)
    {
      this._userRepository = userRepository;
      this._hasher = hasher;
      this._jwtFactory = jwtFactory;
    }

    public AccountModel Login(LoginModel loginModel)
    {
      if (loginModel == null)
        throw new ArgumentNullException(nameof(loginModel));

      if (string.IsNullOrEmpty(loginModel.Email) ||
          string.IsNullOrEmpty(loginModel.Password))
        throw new ArgumentException("Email and Password cannot be null");

      var currentUser = _userRepository.GetUserByEmail(loginModel.Email);
      if (currentUser == null)
        throw new DomainException("User with the email of '{0}' does not exist.", loginModel.Email);

      var passwordIsValid = _hasher.VerifyHashedPassword(currentUser, currentUser.Password, loginModel.Password);
      if (passwordIsValid.Equals(PasswordVerificationResult.Failed))
        throw new DomainException("User's password with the email of '{0}' is not correct.", loginModel.Email);


      return GenerateToken(currentUser);
    }

    private AccountModel GenerateToken(User user)
    {
      var userId = user.Id.ToString();
      var token = this._jwtFactory.GenerateEncodedToken(userId);
      var accountModel = Mapper.Map<AccountModel>(user);
      accountModel.Token = token;
      return accountModel;
    }

    public Guid Register(RegisterModel registerModel)
    {
      if (registerModel == null)
        throw new ArgumentNullException(nameof(registerModel));

      if (string.IsNullOrEmpty(registerModel.Email) || 
          string.IsNullOrEmpty(registerModel.Password) || 
          string.IsNullOrEmpty(registerModel.UserName))
        throw new ArgumentException();

      bool userIsExist = _userRepository.EmailExists(registerModel.Email);
      if (userIsExist)
        throw new DomainException("User with the email of '{0}' already exists. ", registerModel.Email);

      User newUser = new User()
      {
        Id = Guid.NewGuid(),
        Email = registerModel.Email,
        UserName = registerModel.UserName,
      };
      newUser.Password = _hasher.HashPassword(newUser, registerModel.Password);
      newUser.CreateUserProfile();
      _userRepository.Add(newUser);
      Context.Commit();
      return newUser.Id;
    }
  }
}
