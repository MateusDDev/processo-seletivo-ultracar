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

    public ICollection<StockMovement> GetStockMovementsByPartId(int partId)
    {
        var stockMovements = _context.StockMovements.Where(sm => sm.PartId == partId).ToList();
        return stockMovements;
    }
    
    public StockMovement GetEntryStockMovementByPartId(int partId)
    {
        var movement = _context.StockMovements
        .FirstOrDefault(sm => sm.Type == StockMovementType.Entry && sm.PartId == partId)
        
        ?? throw new KeyNotFoundException("Movimentação de estoque referente a peça não foi encontrada");

        return movement;
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