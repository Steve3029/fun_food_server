﻿using FunFoodServer.Domain.Model;
using FunFoodServer.Repositories.EntityFramework.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FunFoodServer.Repositories.EntityFramework
{
  internal class FunFoodDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
      modelBuilder.ApplyConfiguration(new UserProfileTypeConfiguration());
    }
  }
}
