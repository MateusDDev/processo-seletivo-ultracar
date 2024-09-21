using Ultracar.Database;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

namespace Ultracar.Repositories;

public class PartRepository: IPartRepository
{
    private readonly IUltracarContext _context;
    private readonly IStockMovementsRepository _movementsRepository;

    public PartRepository(IUltracarContext context, IStockMovementsRepository movementsRepository)
    {
        _context = context;
        _movementsRepository = movementsRepository;
    }

    public ICollection<Part> GetParts()
    {
        var parts = _context.Parts.ToList();
        return parts;
    }

    public Part AddPart(PartDTO partDTO)
    {
        var newPart = _context.Parts.Add(new Part
        {
            Name = partDTO.Name,
            Stock = partDTO.Stock
        }).Entity;
        _context.SaveChanges();

        _movementsRepository.AddStockMovement(new StockMovement
        {
            PartId = newPart.Id,
            MovementDate = DateTime.UtcNow,
            Quantity = newPart.Stock,
            Type = StockMovementType.Entry
        });

        return newPart;
    }
}