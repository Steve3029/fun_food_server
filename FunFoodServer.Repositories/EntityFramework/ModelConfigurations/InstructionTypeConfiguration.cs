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
      builder.ToTable("T_INSTRUCTION", "FunFoodFinal");
             
      builder.Property(s => s.Id).ValueGeneratedNever();

      builder.Property(s => s.OrderNumber)
             .IsRequired()
             .HasMaxLength(3);

      builder.Property(s => s.ImageUrl)
             .HasColumnName("ImageURL")
             .HasMaxLength(200);

      builder.Property(s => s.Description)
             .IsRequired()
             .HasMaxLength(300);

      builder.HasOne(s => s.Recipe)
             .WithMany(r => r.Instructions)
             .HasForeignKey(s => s.RecipeId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_T_INSTRUCTION_T_RECIPE");
    }
  }
}
