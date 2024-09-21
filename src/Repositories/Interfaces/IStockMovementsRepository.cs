using Ultracar.Models;

public interface IStockMovementsRepository
{
    ICollection<StockMovement> GetStockMovements();
    StockMovement AddStockMovement(StockMovement stockMovement);
}