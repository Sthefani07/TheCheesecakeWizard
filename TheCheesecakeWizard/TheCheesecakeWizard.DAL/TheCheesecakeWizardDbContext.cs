using Microsoft.EntityFrameworkCore;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.DAL;

public class TheCheesecakeWizardDbContext : DbContext
{
    public DbSet<Cheesecake> Cheesecakes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public TheCheesecakeWizardDbContext(DbContextOptions<TheCheesecakeWizardDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TheCheesecakeWizard;ConnectRetryCount=0");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCheesecakeIngredientEntity(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureCheesecakeIngredientEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheesecakeIngredient>()
            .HasKey(ci => new { ci.CheesecakeId, ci.IngredientId });

        modelBuilder.Entity<CheesecakeIngredient>()
            .HasOne(ci => ci.Cheesecake)
            .WithMany(c => c.CheesecakeIngredients)
            .HasForeignKey(ci => ci.CheesecakeId);

        modelBuilder.Entity<CheesecakeIngredient>()
            .HasOne(ci => ci.Ingredient)
            .WithMany(i => i.CheesecakeIngredients)
            .HasForeignKey(ci => ci.IngredientId);
    }
}