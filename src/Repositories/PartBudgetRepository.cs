using Ultracar.Database;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

namespace Ultracar.Repositories;

public class PartBudgetRepository: IPartBudgetRepository
{
    private readonly UltracarContext _context;

    public PartBudgetRepository(UltracarContext context)
    {
        _context = context;
    }

    public PartBudget AddPartToBudget(int budgetId, int partId)
    {
        var partBudget = new PartBudget
        {
            BudgetId = budgetId,
            PartId = partId,
            Status = "Pending"
        };
        var newPartBudget = _context.PartBudgets.Add(partBudget).Entity;
        _context.SaveChanges();

        return newPartBudget;
    }
}