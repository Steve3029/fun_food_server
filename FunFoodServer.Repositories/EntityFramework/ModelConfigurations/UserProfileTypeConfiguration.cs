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
        .HasKey(u => u.Id);

      builder.Property(t => t.UserId)
             .IsRequired();

      builder.Property(t => t.FirstName)
        .HasMaxLength(50);

      builder.Property(t => t.LastName)
        .HasMaxLength(50);

      builder.Property(t => t.Gender)
        .HasDefaultValue(0)
        .HasMaxLength(1);

      builder.Property(t => t.Birthday)
        .HasDefaultValue(DateTime.Today);

      builder.Property(t => t.Location)
        .HasMaxLength(100);

      builder.Property(t => t.GooglePlus)
        .HasMaxLength(50);

      builder.Property(t => t.Facebook)
        .HasMaxLength(50);

      builder.Property(t => t.Twitter)
        .HasMaxLength(50);

      builder.Property(t => t.Youtube)
        .HasMaxLength(50);
    }
  }
}
