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
      builder.ToTable("T_CATEGORIES");

      builder.HasKey(t => t.Id);
      builder.Property(t => t.Name)
             .IsRequired()
             .HasMaxLength(100);
      builder.Property(t => t.Description)
             .HasMaxLength(200);
      builder.HasMany(t => t.Recipes)
             .WithOne(r => r.Category);
    }
  }
}
