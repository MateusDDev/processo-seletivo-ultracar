using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IDeliveryRepository
{
    ICollection<Delivery> GetDeliveries();
    Task<Delivery> DeliveryPart(int partBudgetId, string cep);
}