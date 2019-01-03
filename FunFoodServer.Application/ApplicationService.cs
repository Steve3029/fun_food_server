using System;
using FunFoodServer.Domain.Repositories;
using AutoMapper;
using FunFoodServer.Domain.Model;
using FunFoodServer.Application.Model;

namespace FunFoodServer.Application
{
  public abstract class ApplicationService
  {
    private readonly IRepositoryContext _context;

    protected ApplicationService(IRepositoryContext context)
    {
      this._context = context;
    }

    public IRepositoryContext Context { get; }

    public static void Initialize()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<LoginModel, User>();
        cfg.CreateMap<User, LoginModel>();
      });
    }
  }
}
