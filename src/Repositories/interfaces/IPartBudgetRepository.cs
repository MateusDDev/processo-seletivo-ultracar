using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IPartBudgetRepository
{
    PartBudget AddPartToBudget(int budgetId, int partId);
}