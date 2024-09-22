using Microsoft.EntityFrameworkCore;
using Ultracar.Database;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;
using Ultracar.Services;

namespace Ultracar.Repositories;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly IUltracarContext _context;
    private readonly ViaCEP _service;
    private readonly IStockMovementsRepository _stockMovementsRepository;
    private readonly IPartBudgetRepository _partBudgetRepository;

    public DeliveryRepository(IUltracarContext context, IStockMovementsRepository stockMovementsRepository, IPartBudgetRepository partBudgetRepository)
    {
        _context = context;
        _service = new ViaCEP();
        _stockMovementsRepository = stockMovementsRepository;
        _partBudgetRepository = partBudgetRepository;
    }

    public ICollection<Delivery> GetDeliveries()
    {
        var deliveries = _context.Deliveries.Include(d => d.StockMovement).ToList();
        return deliveries;
    }

    public Delivery GetDelivery(int deliveryId)
    {
        var delivery = _context.Deliveries.FirstOrDefault(d => d.Id == deliveryId)
        ?? throw new KeyNotFoundException("Entrega não encontrada");

        return delivery;
    }

    public async Task<Delivery> DeliveryPart(DeliveryDTO deliveryDTO)
    {
        var partBudget = _partBudgetRepository.GetPartBudget(deliveryDTO.PartBudgetId);

        if (partBudget.Status == PartBudgetStatus.Delivered)
            throw new InvalidOperationException("Entrega já realizada");
        
        partBudget.Part.Stock -= 1;
        partBudget.Status = PartBudgetStatus.Delivered;

        var stockMovement = _stockMovementsRepository.AddStockMovement(new StockMovement
        {
            MovementDate = DateTime.UtcNow,
            PartId = partBudget.Part.Id,
            Quantity = 1,
            Type = StockMovementType.Exit
        });

        var address = await _service.FormattedAddress(deliveryDTO.Cep);
        var newDelivery = _context.Deliveries.Add(
        new Delivery
        {
            Address = address,
            PartBudgetId = deliveryDTO.PartBudgetId,
            StockMovementId = stockMovement.Id
        }
        ).Entity;
        _context.SaveChanges();

        return newDelivery;
    }

    public void DeleteDelivery(int deliveryId)
    {
        var delivery = GetDelivery(deliveryId);

        var partBudget = _partBudgetRepository.GetPartBudget(delivery.PartBudgetId);
        partBudget.Part.Stock += 1;
        partBudget.Status = PartBudgetStatus.Pending;

        _context.Deliveries.Remove(delivery);
        _stockMovementsRepository.DeleteStockMovement(delivery.StockMovementId);

        _context.SaveChanges();
    }
}