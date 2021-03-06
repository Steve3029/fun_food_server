﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FunFoodServer.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using FunFoodServer.WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FunFoodServer.Application;
using FunFoodServer.Application.Implementation;
using FunFoodServer.Domain.Repositories;
using FunFoodServer.Repositories;

namespace FunFoodServer.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var dbConnection = Configuration.GetValue<string>("DefaultConnection");
      Console.WriteLine(dbConnection);

      services.AddDbContext<FunFoodDbContext>(options => options.UseSqlServer(dbConnection));
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddCors();
      services.AddAutoMapper();

      // configuration object
      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      // cloudinary configuration
      var cloudinarySection = Configuration.GetSection("Cloudinary");
      services.Configure<CloudinaryConfig>(cloudinarySection);

      // JWT configuration
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      services.AddAuthentication(authOptions =>
      {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(jwtConfig => 
      {
        jwtConfig.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = appSettings.Issuer,
          ValidateAudience = false,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key)
        };
      });
      // End JWT configuring
      services.AddScoped<DbContext, FunFoodDbContext>();
      services.AddScoped<IIdentityService, IdentityServiceImpl>();
      services.AddScoped<IRepositoryContext, EntityFrameworkRepositoryContext>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IRecipeRepository, RecipeRepository>();
      services.AddScoped<IRecipeService, RecipeServiceImpl>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseCors(builder =>
        builder.AllowAnyOrigin()
               .AllowAnyHeader());
      app.UseHttpsRedirection();
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
