using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class FavoriteTypeConfiguration : IEntityTypeConfiguration<Favorite>
  {
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
      builder.HasKey(f => new { f.UserId, f.RecipeId });

      builder.ToTable("T_FAVORITE", "FunFoodFinal");

      builder.HasOne(f => f.User)
             .WithMany(u => u.Favorites)
             .HasForeignKey(f => f.UserId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_T_FAVORITE_T_USER");

      builder.HasOne(f => f.Recipe)
             .WithMany(r => r.Favorites)
             .HasForeignKey(f => f.RecipeId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_T_FAVORITE_T_RECIPE");
    }
  }
}
