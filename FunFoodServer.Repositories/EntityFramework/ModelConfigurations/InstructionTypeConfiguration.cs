using System;
using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class InstructionTypeConfiguration : IEntityTypeConfiguration<Instruction>
  {

    public void Configure(EntityTypeBuilder<Instruction> builder)
    {
      builder.ToTable("T_INSTRUCTION")
             .HasKey(s => s.Id);

      builder.Property(s => s.Index)
             .IsRequired();

      builder.Property(s => s.ImageUrl)
             .HasMaxLength(100);

      builder.Property(s => s.Description)
             .HasMaxLength(300);
    }
  }
}
