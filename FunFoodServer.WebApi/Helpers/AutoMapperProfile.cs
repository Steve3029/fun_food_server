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
      CreateMap<Recipe, RecipeDTO>()
        .ForMember(d => d.Serve, o => o.MapFrom(s => s.Serving))
        .ForMember(d => d.CoverImage, o => o.MapFrom(s => s.CoverImageUrl));
      CreateMap<IngredientDTO, Ingredient>()
        .ForMember(d => d.Unit, o => o.MapFrom(s => s.Quantity));
      CreateMap<Ingredient, IngredientDTO>()
        .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Unit));
      CreateMap<InstructionDTO, Instruction>();
      CreateMap<Instruction, InstructionDTO>();
    }
  }
}
