using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("T_CATEGORIES")
             .HasKey(c => c.Id);

      builder.Property(c => c.Name)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(c => c.Description)
             .HasMaxLength(500);

      builder.HasMany(c => c.Recipes)
             .WithOne();
    }
  }
}
