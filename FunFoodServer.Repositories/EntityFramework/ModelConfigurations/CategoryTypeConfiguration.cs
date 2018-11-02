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
      builder.ToTable("T_CATEGORY", "FunFoodFinal");
             
      builder.Property(e => e.Id).ValueGeneratedNever();

      builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(e => e.Description)
             .HasMaxLength(500);
    }
  }
}
