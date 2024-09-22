using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IBudgetRepository
{
    ICollection<Budget> GetBudgets();
    Budget GetBudget(int id);
    Budget AddBudget(BudgetDTO budgetDTO);

    Budget UpdateBudget(BudgetDTO budgetDTO, int budgetId);
}