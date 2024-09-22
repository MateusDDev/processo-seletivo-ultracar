using Ultracar.Models;

public interface IStockMovementsRepository
{
    ICollection<StockMovement> GetStockMovements();
    StockMovement GetStockMovement(int stockMovementId);
    StockMovement AddStockMovement(StockMovement stockMovement);
    void DeleteStockMovement(int stockMovementId);
}