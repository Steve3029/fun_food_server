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
      builder.ToTable("T_INGREDIENT")
             .HasKey(i => i.Id);

      builder.Property(i => i.Index)
             .IsRequired();

      builder.Property(i => i.Name)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(i => i.Unit)
             .IsRequired()
             .HasMaxLength(100);

    }
  }
}
