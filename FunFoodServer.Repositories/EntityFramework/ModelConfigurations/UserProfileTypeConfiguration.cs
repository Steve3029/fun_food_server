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
      builder.ToTable("T_USER_PROFILE")
        .HasKey(up => up.Id);

      builder.Property(up => up.FirstName)
        .HasMaxLength(50);

      builder.Property(up => up.LastName)
        .HasMaxLength(50);

      builder.Property(up => up.Gender)
        .HasDefaultValue('M');

      builder.Property(up => up.Birthday);

      builder.Property(up => up.Location)
        .HasMaxLength(100);

      builder.Property(up => up.GooglePlus)
        .HasMaxLength(100);

      builder.Property(up => up.Facebook)
        .HasMaxLength(100);

      builder.Property(up => up.Twitter)
        .HasMaxLength(100);

      builder.Property(up => up.Youtube)
        .HasMaxLength(100);
    }
  }
}
