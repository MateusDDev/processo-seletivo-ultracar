using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IPartBudgetRepository
{
    ICollection<PartBudget> GetPartBudgets();
    PartBudget GetPartBudget(int partBudgetId);
    PartBudget AddPartToBudget(PartBudgetDTO partBudgetDTO);
    PartBudget UpdatePartBudget(PartBudgetDTO partBudgetDTO, int partBudgetId);
    void DeletePartBudget(int partBudgetId);
}