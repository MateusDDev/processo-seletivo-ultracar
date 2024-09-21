using Ultracar.Database;
using Ultracar.Models;

public class BudgetRepository: IBudgetRepository
{
    private readonly IUltracarContext _context;

    public BudgetRepository(IUltracarContext context)
    {
        _context = context;
    }

    public ICollection<Budget> GetBudgets()
    {
        var budgets = _context.Budgets.ToList();
        return budgets;
    }

    public Budget AddBudget(BudgetDTO budgetDTO)
    {
        var newBudget = _context.Budgets.Add(new Budget
        {
            ClientName = budgetDTO.ClientName,
            Number = budgetDTO.Number,
            VehiclePlate = budgetDTO.VehiclePlate
        }).Entity;
        _context.SaveChanges();

        return newBudget;
    }
}