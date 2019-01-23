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
          return StatusCode(422);

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
        return BadRequest("Data of register cannot be null.");
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
        var userId = _identityService.SignUp(user, userDTO.Password);

        return CreatedAtAction("SignIn", new UserDTO() { Id = userId, Email = user.Email });

      }
      catch(DomainException dx)
      {
        return Conflict();
      }
      catch (Exception ex)
      {
        return BadRequest("Information required to sign up cannot be empty.");
      }
    }
  }
}
