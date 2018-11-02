using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class IngredientTypeConfiguration : IEntityTypeConfiguration<Ingredient>
  {

    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
      builder.ToTable("T_INGREDIENT", "FunFoodFinal");

      builder.Property(i => i.Id).ValueGeneratedNever();

      builder.Property(i => i.OrderNumber)
             .IsRequired()
             .HasMaxLength(3);

      builder.Property(i => i.Name)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(i => i.Unit)
             .IsRequired()
             .HasMaxLength(100);

      builder.HasOne(i => i.Recipe)
             .WithMany(r => r.Ingredients)
             .HasForeignKey(i => i.RecipeId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_T_INGREDIENT_T_RECIPE");

    }
  }
}
