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

    public Part GetPart(int partId)
    {
        var part = _context.Parts.FirstOrDefault(p => p.Id == partId)
        ?? throw new KeyNotFoundException("Peça não encontrada");

        return part;
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

    public Part UpdatePart(PartDTO partDTO, int partId)
    {
        var part = GetPart(partId);

        part.Name = partDTO.Name;
        part.Stock = partDTO.Stock;

        var movement = _movementsRepository.GetEntryStockMovementByPartId(partId);

        movement.MovementDate = DateTime.UtcNow;
        movement.Quantity = partDTO.Stock;

        _context.SaveChanges();

        return part;
    }

    public void DeletePart(int partId)
    {
        var part = GetPart(partId);

        _context.Parts.Remove(part);
        _context.SaveChanges();
    }
}