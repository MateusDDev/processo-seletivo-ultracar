using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IPartRepository
{
    ICollection<Part> GetParts();
    Part GetPart(int partId);
    Part AddPart(PartDTO partDTO);
    Part UpdatePart(PartDTO partDTO, int partId);
    void DeletePart(int partId);
}