using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IPartBudgetRepository
{
    ICollection<PartBudget> GetPartBudgets();
    PartBudget AddPartToBudget(PartBudgetDTO partBudgetDTO);
}