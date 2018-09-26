using FunFoodServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFoodServer.Repositories.EntityFramework.ModelConfigurations
{
  internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("USER");
      builder.HasKey(u => u.Id);
      builder.HasIndex(u => u.Email)
        .HasName("Index_Email");

      builder.Property(t => t.Email)
        .IsRequired();


      builder.HasOne(s => s.Profile)
        .WithOne(p => p.User)
        .HasForeignKey<UserProfile>(p => p.UserId);
             
    }
  }
}
