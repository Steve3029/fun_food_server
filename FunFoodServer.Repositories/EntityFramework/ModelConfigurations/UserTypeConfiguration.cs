using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("T_USERS");
      builder.HasKey(u => u.Id);
      builder.HasIndex(i => i.Email)
        .HasName("Index_Email");

      builder.Property(t => t.Email)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(t => t.UserName)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(t => t.Password)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(t => t.PhotoUrl)
        .HasMaxLength(100);


      builder.HasOne(f => f.Profile)
        .WithOne()
        .HasForeignKey<UserProfile>(p => p.UserId);

      builder.HasMany(t => t.Recipes)
             .WithOne(r => r.User);
             
    }
  }
}
