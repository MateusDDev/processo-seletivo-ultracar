using Ultracar.Models;

public interface IBudgetRepository
{
    ICollection<Budget> GetBudgets();
    Budget AddBudget(BudgetDTO budgetDTO);
}