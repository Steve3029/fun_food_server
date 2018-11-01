using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("T_USERS")
             .HasKey(u => u.Id);

      builder.HasIndex(u => u.Email)
             .HasName("Index_Email");

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
             .HasMaxLength(100);

      builder.Property(u => u.CreateDate)
             .IsRequired()
             .HasDefaultValueSql("getdate()");

      builder.HasOne(u => u.Profile)
             .WithOne(up => up.User)
             .HasForeignKey<UserProfile>(up => up.UserId);

      builder.HasMany(u => u.Recipes)
             .WithOne();
             
    }
  }
}
