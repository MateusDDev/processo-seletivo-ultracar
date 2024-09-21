using Ultracar.Database;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

public class PartRepository: IPartRepository
{
    private readonly IUltracarContext _context;

    public PartRepository(IUltracarContext context)
    {
        _context = context;
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

        return newPart;
    }
}