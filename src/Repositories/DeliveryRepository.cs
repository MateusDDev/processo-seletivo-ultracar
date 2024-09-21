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

    public DeliveryRepository(IUltracarContext context)
    {
        _context = context;
        _service = new ViaCEP();
    }

    public ICollection<Delivery> GetDeliveries()
    {
        var deliveries = _context.Deliveries.ToList();
        return deliveries;
    }

    public async Task<Delivery> DeliveryPart(int partBudgetId, string cep)
    {
        var partBudget = _context.PartBudgets
        .Where(pb => pb.Id == partBudgetId)
        .Include(pb => pb.Part)
        .FirstOrDefault();

        if (partBudget == null)
            throw new Exception("Peça relacionada ao orçamento não encontrada");

        if (partBudget.Status != PartBudgetStatus.Pending)
            throw new Exception("Entrega já realizada");
        
        partBudget.Part.Stock -= 1;
        partBudget.Status = PartBudgetStatus.Delivered;

        var address = await _service.GetAddress(cep);
        var newDelivery = _context.Deliveries.Add(new Delivery
        {
            Address = $"{address.Estado} - {address.Localidade} - {address.Bairro} - {address.Logradouro}",
            PartBudgetId = partBudgetId
        }).Entity;
        _context.SaveChanges();

        return newDelivery;
    }
}