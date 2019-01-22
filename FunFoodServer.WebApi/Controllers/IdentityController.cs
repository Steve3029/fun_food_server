using System;
using FunFoodServer.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FunFoodServer.WebApi.Helpers;
using Microsoft.Extensions.Options;
using FunFoodServer.WebApi.DTOs;
using FunFoodServer.Domain.Model;
using FunFoodServer.Domain;

namespace FunFoodServer.WebApi.Controllers
{
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

    [HttpPost("signin")]
    public IActionResult SignIn(UserDTO userDTO)
    {
      try
      {
        ValidationResult result = _identityService.ValidationPassword(userDTO.Email, userDTO.PassWord);

        if (!result.Succeeded)
          return BadRequest(422);

        // generate a token and return
        var user = result.User;
        var token = JwtTokenGenerator.GenerateToken(result.User, _appSettings.Issuer, _appSettings.Secret);

        return Ok(new UserDTO() 
        {
          Id = user.Id,
          Email = user.Email,
          Token = token
        });
      }
      catch (Exception ex)
      {
        return BadRequest("Password or Email is empty.");
      }
    }

    [HttpPost("signup")]
    public IActionResult SignUp(UserDTO userDTO)
    {
      try
      {
        var user = _mapper.Map<User>(userDTO);
        var userId = _identityService.SignUp(user, userDTO.PassWord);

        return CreatedAtAction("SignIn", new UserDTO() { Id = user.Id, Email = user.Email });

      }
      catch(DomainException dx)
      {
        return Conflict();
      }
      catch (Exception ex)
      {
        return BadRequest("Email or Password is empty.");
      }
    }
  }
}
