using FunFoodServer.Domain.Model;
using FunFoodServer.Repositories.EntityFramework.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FunFoodServer.Repositories.EntityFramework
{
  internal class FunFoodDbContext : DbContext
  {
    public FunFoodDbContext()
    {
    }

    public FunFoodDbContext(DbContextOptions<FunFoodDbContext> options)
      :base(options)
    {
    }

    public DbSet<Category> Category { get; set; }

    public DbSet<Favorite> Favorite { get; set; }

    public DbSet<Ingredient> Ingredient { get; set; }

    public DbSet<Instruction> Instruction { get; set; }

    public DbSet<Recipe> Recipe { get; set; }

    public DbSet<RecipeRating> RecipeRating { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"");
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("FunFoodFinal");
      modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
      modelBuilder.ApplyConfiguration(new FavoriteTypeConfiguration());
      modelBuilder.ApplyConfiguration(new IngredientTypeConfiguration());
      modelBuilder.ApplyConfiguration(new InstructionTypeConfiguration());
      modelBuilder.ApplyConfiguration(new RecipeTypeConfiguration());
      modelBuilder.ApplyConfiguration(new RecipeRatingTypeConfiguration());
      modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
      modelBuilder.ApplyConfiguration(new UserProfileTypeConfiguration());
     

      base.OnModelCreating(modelBuilder);
    }
  }
}
