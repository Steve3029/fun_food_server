using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class UserProfileTypeConfiguration : IEntityTypeConfiguration<UserProfile>
  {
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
      builder.ToTable("USER_PROFILE")
        .HasKey(p => p.Id);

      builder.HasOne(e => e.User)
        .WithOne(u => u.Profile)
        .HasForeignKey<UserProfile>(f => f.UserId);
    }
  }
}
