using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class RecipeTypeConfiguration : IEntityTypeConfiguration<Recipe>
  {
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
      builder.ToTable("T_RECIPES")
             .HasKey(r => r.Id);

      builder.Property(r => r.Title)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(r => r.Subtitle)
             .IsRequired()
             .HasMaxLength(150);

      builder.Property(r => r.Description)
             .IsRequired()
             .HasMaxLength(500);

      builder.Property(r => r.CoverImageUrl)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(r => r.Serving)
             .IsRequired();

      builder.Property(r => r.CreateDate)
             .HasDefaultValueSql("getdate()");

      builder.HasMany(r => r.Ingredients)
             .WithOne();

      builder.HasMany(r => r.Instructions)
             .WithOne();

      builder.HasMany(r => r.Ratings)
             .WithOne();


    }
  }
}
