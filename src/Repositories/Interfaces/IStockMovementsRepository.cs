using Ultracar.Models;

public interface IStockMovementsRepository
{
    ICollection<StockMovement> GetStockMovements();
    ICollection<StockMovement> GetStockMovementsByPartId(int partId);
    StockMovement GetEntryStockMovementByPartId(int partId);
    StockMovement GetStockMovement(int stockMovementId);
    StockMovement AddStockMovement(StockMovement stockMovement);
    void DeleteStockMovement(int stockMovementId);
}