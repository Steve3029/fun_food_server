using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("USERS");
      builder.HasKey(u => u.Id);
      builder.HasIndex(i => i.Email)
        .HasName("Index_Email");

      builder.Property(t => t.Email)
        .IsRequired()
        .HasMaxLength(40);

      builder.Property(t => t.UserName)
        .IsRequired()
        .HasMaxLength(30);

      builder.Property(t => t.Password)
        .IsRequired()
        .HasMaxLength(20);

      builder.Property(t => t.PhotoUrl)
        .HasMaxLength(80);


      builder.HasOne(f => f.Profile)
        .WithOne(p => p.User)
        .HasForeignKey<UserProfile>(p => p.UserId);
             
    }
  }
}
