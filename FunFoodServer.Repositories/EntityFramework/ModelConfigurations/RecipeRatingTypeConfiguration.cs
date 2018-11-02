using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  public class RecipeRatingTypeConfiguration : IEntityTypeConfiguration<RecipeRating>
  {
    public void Configure(EntityTypeBuilder<RecipeRating> builder)
    {
      builder.HasKey(ra => new { ra.RecipeId, ra.UserId });

      builder.ToTable("T_RECIPE_RATING", "FunFoodFinal");

      builder.Property(ra => ra.Scores)
             .IsRequired()
             .HasMaxLength(2);
             
      builder.Property(ra => ra.RateDate)
             .HasColumnType("datetime")
             .HasDefaultValueSql("(getdate())");

      builder.HasOne(ra => ra.User)
             .WithMany(u => u.RecipeRatings)
             .HasForeignKey(ra => ra.UserId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_T_RECIPE_RATING_T_USER");

      builder.HasOne(ra => ra.Recipe)
             .WithMany(r => r.RecipeRatings)
             .HasForeignKey(ra => ra.RecipeId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_T_RECIPE_RATING_T_CATEGORY");
    }
  }
}
