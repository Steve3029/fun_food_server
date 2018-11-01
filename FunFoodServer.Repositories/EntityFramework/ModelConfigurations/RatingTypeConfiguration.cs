using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  public class RatingTypeConfiguration : IEntityTypeConfiguration<Rating>
  {
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
      builder.ToTable("T_RATING")
             .HasKey(ra => new { ra.UserId, ra.RecipeId});

      builder.Property(ra => ra.Scores)
             .IsRequired();

      builder.Property(ra => ra.RateDate)
             .HasDefaultValueSql("getdate()");

      builder.HasOne(ra => ra.User)
             .WithMany()
             .HasForeignKey(ra => ra.UserId);

      builder.HasOne(ra => ra.Recipe)
             .WithMany()
             .HasForeignKey(ra => ra.RecipeId);
    }
  }
}
