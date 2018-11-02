using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("T_USER", "FunFoodFinal");

      builder.Property(u => u.Id).ValueGeneratedNever();

      builder.Property(u => u.Email)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(u => u.UserName)
             .IsRequired()
             .HasMaxLength(50);

      builder.Property(u => u.Password)
             .IsRequired()
             .HasMaxLength(50);

      builder.Property(u => u.PhotoUrl)
             .HasColumnName("PhotoURL")
             .HasMaxLength(100);

      builder.Property(u => u.CreatedDate)
             .HasDefaultValueSql("(getdate())");

      builder.HasIndex(u => u.Email)
             .HasName("Index_Email")
             .IsUnique();
             
    }
  }
}
