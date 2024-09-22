using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IDeliveryRepository
{
    ICollection<Delivery> GetDeliveries();
    Delivery GetDelivery(int deliveryId);
    Task<Delivery> DeliveryPart(DeliveryDTO deliveryDTO);
    void DeleteDelivery(int deliveryId);
}