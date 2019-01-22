using System;
using AutoMapper;
using FunFoodServer.Domain.Model;
using FunFoodServer.WebApi.DTOs;

namespace FunFoodServer.WebApi.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserDTO>();
      CreateMap<UserDTO, User>();
    }
  }
}
