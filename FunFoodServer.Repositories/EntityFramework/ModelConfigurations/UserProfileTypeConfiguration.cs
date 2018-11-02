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
      builder.ToTable("T_USER_PROFILE", "FunFoodFinal");

      builder.HasIndex(up => up.UserId)
             .HasName("IX_T_USERPROFILE")
             .IsUnique();
        
      builder.Property(up => up.Id).ValueGeneratedNever();

      builder.Property(up => up.FirstName)
        .HasMaxLength(50);

      builder.Property(up => up.LastName)
        .HasMaxLength(50);

      builder.Property(up => up.Gender)
             .IsRequired()
             .HasMaxLength(1)
             .HasDefaultValue("('M')");

      builder.Property(up => up.Birthday)
             .HasColumnType("date");

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

      builder.HasOne(up => up.User)
             .WithOne(u => u.UserProfile)
             .HasForeignKey<UserProfile>(up => up.UserId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_T_USERPROFILE_T_USER");
    }
  }
}
