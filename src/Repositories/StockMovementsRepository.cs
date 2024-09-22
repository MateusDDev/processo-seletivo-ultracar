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

    public StockMovement GetStockMovement(int stockMovementId)
    {
        var movement = _context.StockMovements.FirstOrDefault(s => s.Id == stockMovementId)
        ?? throw new KeyNotFoundException("Movimentação não encontrada");

        return movement;
    }

    public StockMovement AddStockMovement(StockMovement stockMovement)
    {
        var newMovement = _context.StockMovements.Add(stockMovement).Entity;
        _context.SaveChanges();
        return newMovement;
    }

    public void DeleteStockMovement(int stockMovementId)
    {
        var movement = GetStockMovement(stockMovementId);
        _context.StockMovements.Remove(movement);
        _context.SaveChanges();
    }
}