using System;
using FunFoodServer.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FunFoodServer.WebApi.Helpers;
using Microsoft.Extensions.Options;

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


  }
}
