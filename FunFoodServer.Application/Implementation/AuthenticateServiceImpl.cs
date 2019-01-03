using System;
using AutoMapper;
using FunFoodServer.Application.Model;
using FunFoodServer.Domain;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain.Repositories;

namespace FunFoodServer.Application.Implementation
{
  public class AuthenticateServiceImpl : ApplicationService, IAuthenticateService
  {
    private readonly IUserRepository _userRepository;

    public AuthenticateServiceImpl(IRepositoryContext context, IUserRepository userRepository)
      : base(context)
    {
      this._userRepository = userRepository;
    }

    public AccountModel Login(LoginModel loginModel)
    {
      if (loginModel == null)
        throw new ArgumentNullException(nameof(loginModel));

      if (string.IsNullOrEmpty(loginModel.Email) ||
          string.IsNullOrEmpty(loginModel.Password))
        throw new ArgumentException("Email and Password cannot be null");

      User currentUser = _userRepository.GetUserByEmail(loginModel.Email);
      return null;
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

      User newUser = Mapper.Map<User>(registerModel);
      newUser.Id = Guid.NewGuid();
      newUser.CreateUserProfile();
      _userRepository.Add(newUser);
      Context.Commit();
      return newUser.Id;
    }
  }
}
