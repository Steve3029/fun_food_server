using System;
using FunFoodServer.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FunFoodServer.WebApi.Helpers;
using Microsoft.Extensions.Options;
using FunFoodServer.WebApi.DTOs;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain;
using Microsoft.AspNetCore.Authorization;

namespace FunFoodServer.WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/v1/[controller]")]
  public class IdentityController : ControllerBase
  {
    private readonly IIdentityService _identityService;

    private readonly IMapper _mapper;

    private readonly AppSettings _appSettings;

    public IdentityController(IIdentityService service, IMapper mapper, IOptions<AppSettings> appSettings)
    {
      this._identityService = service;
      this._mapper = mapper;
      this._appSettings = appSettings.Value;
    }

    // Post: api/v1/signin
    [AllowAnonymous]
    [HttpPost("signin")]
    public IActionResult SignIn(UserDTO userDTO)
    {
      try
      {
        ValidationResult result = _identityService.ValidationPassword(userDTO.Email, userDTO.Password);

        if (!result.Succeeded)
          return StatusCode(422, "Email or Password is not correct.");

        // generate a token and return
        var user = result.User;
        var token = JwtTokenGenerator.GenerateToken(result.User, _appSettings.Issuer, _appSettings.Secret);

        return Ok(new UserDTO() 
        {
          Id = user.Id,
          UserName = user.UserName,
          Email = user.Email,
          Token = token
        });
      }
      catch (Exception ex)
      {
        return BadRequest("Sorry sign in is failed.");
      }
    }

    // Post: api/v1/signup
    [AllowAnonymous]
    [HttpPost("signup")]
    public IActionResult SignUp(UserDTO userDTO)
    {
      try
      {
        var user = _mapper.Map<User>(userDTO);
        user = _identityService.SignUp(user, userDTO.Password);

        var token = JwtTokenGenerator.GenerateToken(user, _appSettings.Issuer, _appSettings.Secret);

        return Ok(new UserDTO()
        {
          Id = user.Id,
          UserName = user.UserName,
          Email = user.Email,
          Token = token
        });

      }
      catch(DomainException dx)
      {
        return Conflict("This email has already been registered.");
      }
      catch (Exception ex)
      {
        return BadRequest("Sorry, sign up is failed.");
      }
    }
  }
}
