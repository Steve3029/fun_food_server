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
             .HasKey(t => t.Id);

      builder.Property(t => t.Title)
             .IsRequired()
             .HasMaxLength(200);

      builder.Property(t => t.BriefDesc)
             .IsRequired()
             .HasMaxLength(200);

      builder.Property(t => t.Description)
             .HasMaxLength(500);

      builder.Property(t => t.CoverImageUrl)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(t => t.Serving)
             .IsRequired();

      builder.Property(t => t.PostDate)
             .IsRequired();

      builder.HasOne(t => t.Category)
             .WithMany(c => c.Recipes)
             .IsRequired()
             .OnDelete(DeleteBehavior.SetNull);

      builder.HasMany(t => t.Ingredients)
             .WithOne();

      builder.HasMany(t => t.Instructions)
             .WithOne();

      builder.HasMany(t => t.Ratings)
             .WithOne();

      builder.HasOne(t => t.User)
             .WithMany(u => u.Recipes)
             .HasForeignKey(t => t.UserId)
             .OnDelete(DeleteBehavior.Cascade);

    }
  }
}
