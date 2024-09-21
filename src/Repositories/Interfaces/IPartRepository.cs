using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IPartRepository
{
    ICollection<Part> GetParts();
    Part AddPart(PartDTO partDTO);
}