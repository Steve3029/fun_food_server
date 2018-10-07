﻿using FunFoodServer.Domain.Model;
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
        .HasKey(u => u.Id);

      builder.Property(t => t.UserId)
        .IsRequired();

      builder.Property(t => t.FirstName)
        .HasMaxLength(20);

      builder.Property(t => t.LastName)
        .HasMaxLength(20);

      builder.Property(t => t.Gender)
        .HasDefaultValue(0)
        .HasMaxLength(1);

      builder.Property(t => t.Birthday)
        .HasDefaultValue(DateTime.Today);

      builder.Property(t => t.Location)
        .HasMaxLength(30);

      builder.Property(t => t.GooglePlus)
        .HasMaxLength(50);

      builder.Property(t => t.Facebook)
        .HasMaxLength(50);

      builder.Property(t => t.Twitter)
        .HasMaxLength(50);

      builder.Property(t => t.Youtube)
        .HasMaxLength(50);

      builder.HasOne(e => e.User)
        .WithOne(u => u.Profile)
        .HasForeignKey<UserProfile>(f => f.UserId);
    }
  }
}
