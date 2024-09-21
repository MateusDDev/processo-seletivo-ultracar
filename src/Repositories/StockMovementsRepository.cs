using Ultracar.Database;
using Ultracar.Models;

public class StockMovementsRepository : IStockMovementsRepository
{
    private readonly IUltracarContext _context;

    public StockMovementsRepository(IUltracarContext context)
    {
        _context = context;
    }

    public ICollection<StockMovement> GetStockMovements()
    {
        var movements = _context.StockMovements.ToList();
        return movements;
    }

    public StockMovement AddStockMovement(StockMovement stockMovement)
    {
        var newMovement = _context.StockMovements.Add(stockMovement).Entity;
        _context.SaveChanges();
        return newMovement;
    }
}