using Ultracar.Database;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

namespace Ultracar.Repositories;

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

    public Budget GetBudget(int id)
    {
        var budget = _context.Budgets.FirstOrDefault(b => b.Id == id)
        ?? throw new KeyNotFoundException("Orçamento não encontrado");
        return budget;
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

    public Budget UpdateBudget(BudgetDTO budgetDTO, int budgetId)
    {
        var budget = GetBudget(budgetId);

        budget.ClientName = budgetDTO.ClientName;
        budget.Number = budgetDTO.Number;
        budget.VehiclePlate = budgetDTO.VehiclePlate; 
        _context.SaveChanges();

        return budget;
    }

    public void DeleteBudget(int budgetId)
    {
        var budget = GetBudget(budgetId);
        
        _context.Budgets.Remove(budget);
        _context.SaveChanges();
    }
}