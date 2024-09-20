using Microsoft.EntityFrameworkCore;
using Ultracar.Models;

namespace Ultracar.Database;

public interface IUltracarContext
{
    public DbSet<Budget> Budgets {get; set;}
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<PartBudget> PartBudgets { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public int SaveChanges();
}