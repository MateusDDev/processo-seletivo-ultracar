using Ultracar.Models;

namespace Ultracar.Repositories.Interfaces;

public interface IBudgetRepository
{
    ICollection<Budget> GetBudgets();
    Budget AddBudget(BudgetDTO budgetDTO);
}