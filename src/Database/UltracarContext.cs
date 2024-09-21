namespace Ultracar.Database;

using Microsoft.EntityFrameworkCore;
using Ultracar.Models;

public class UltracarContext : DbContext, IUltracarContext
{
    public DbSet<Budget> Budgets {get; set;}
    public DbSet<Delivery> Deliveries {get; set;}
    public DbSet<Part> Parts {get; set;}
    public DbSet<PartBudget> PartBudgets {get; set;}
    public DbSet<StockMovement> StockMovements {get; set;}

    public UltracarContext(DbContextOptions<UltracarContext> options)
        : base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";

        string connectionString = $"Host={host};Port=5432;Database=postgresDB;Username=user;Password=senhacriativa;";
        optionsBuilder.UseNpgsql(connectionString, builder => {
            builder.EnableRetryOnFailure();
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
    }
}