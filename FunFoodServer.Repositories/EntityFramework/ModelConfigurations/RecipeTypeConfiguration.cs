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
      builder.ToTable("T_RECIPES", "FunFoodFinal");
             
      builder.Property(r => r.Id).ValueGeneratedNever();

      builder.Property(r => r.Title)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(r => r.Subtitle)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(r => r.Description)
             .IsRequired()
             .HasMaxLength(500);

      builder.Property(r => r.CoverImageUrl)
             .IsRequired()
             .HasColumnName("CoverImageURL")
             .HasMaxLength(100);

      builder.Property(r => r.Serving)
             .IsRequired()
             .HasMaxLength(3);

      builder.Property(r => r.CreatedDate)
             .HasDefaultValueSql("(getdate())");

      builder.HasOne(r => r.User)
             .WithMany(u => u.Recipes)
             .HasForeignKey(r => r.UserId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_T_RECIPE_T_USER");

      builder.HasOne(r => r.Category)
             .WithMany(c => c.Recipes)
             .HasForeignKey(r => r.CategoryId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_T_RECIPE_T_CATEGORY");

    }
  }
}
