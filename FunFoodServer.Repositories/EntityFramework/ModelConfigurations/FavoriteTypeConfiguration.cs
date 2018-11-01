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
      builder.ToTable("T_FAVORITE")
             .HasKey(f => new { f.UserId, f.RecipeId });

      builder.HasOne(f => f.User)
             .WithMany(u => u.Favorites)
             .HasForeignKey(f => f.UserId);

      builder.HasOne(f => f.Recipe)
             .WithMany(r => r.Favorites)
             .HasForeignKey(f => f.RecipeId);
    }
  }
}
