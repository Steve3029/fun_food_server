﻿using FunFoodServer.Domain.Model;
using FunFoodServer.Repositories.EntityFramework.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FunFoodServer.Repositories.EntityFramework
{
  internal class FunFoodDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"");
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("FunFood");

      modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
      modelBuilder.ApplyConfiguration(new UserProfileTypeConfiguration());

      base.OnModelCreating(modelBuilder);
    }
  }
}