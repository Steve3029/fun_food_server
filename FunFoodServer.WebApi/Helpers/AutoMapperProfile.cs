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
      CreateMap<RecipeDTO, Recipe>()
        .ForMember(d => d.Serving, o => o.MapFrom(s => s.Serve))
        .ForMember(d => d.CoverImageUrl, o => o.MapFrom(s => s.CoverImage));
      CreateMap<IngredientDTO, Ingredient>()
        .ForMember(d => d.Unit, o => o.MapFrom(s => s.Quantity));
      CreateMap<InstructionDTO, Instruction>()
        .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.Shotcut))
        .ForMember(d => d.Description, o => o.MapFrom(s => s.Instruction));
    }
  }
}
