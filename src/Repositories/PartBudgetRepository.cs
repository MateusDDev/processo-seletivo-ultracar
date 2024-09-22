using Microsoft.EntityFrameworkCore;
using Ultracar.Database;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

namespace Ultracar.Repositories;

public class PartBudgetRepository: IPartBudgetRepository
{
    private readonly IUltracarContext _context;

    public PartBudgetRepository(IUltracarContext context)
    {
        _context = context;
    }

    public ICollection<PartBudget> GetPartBudgets()
    {
        var partBudgets = _context.PartBudgets
        .Include(pb => pb.Part)
        .Include(pb => pb.Budget)
        .ToList();
        return partBudgets;
    }

    public PartBudget GetPartBudget(int partBudgetId)
    {
        var partBudget = _context.PartBudgets
        .Include(pb => pb.Part)
        .Include(pb => pb.Budget)
        .FirstOrDefault(pb => pb.Id == partBudgetId)

        ?? throw new KeyNotFoundException("Peça relacionada ao orçamento não encontrada");

        return partBudget;
    }

    public PartBudget AddPartToBudget(PartBudgetDTO partBudgetDTO)
    {
        var part = _context.Parts.FirstOrDefault(p => p.Id == partBudgetDTO.PartId)
        ?? throw new KeyNotFoundException("Peça não encontrada");

        var budget = _context.Budgets.FirstOrDefault(b => b.Id == partBudgetDTO.BudgetId)
        ?? throw new KeyNotFoundException("Orçamento não encontrado");


        var newPartBudget = _context.PartBudgets.Add(new PartBudget
        {
            BudgetId = partBudgetDTO.BudgetId,
            PartId = partBudgetDTO.PartId,
            Status = PartBudgetStatus.Pending
        }).Entity;
        _context.SaveChanges();

        var partBudget = _context.PartBudgets
        .Include(pb => pb.Part)
        .Include(pb => pb.Budget)
        .First(pb => pb.Id == newPartBudget.Id);

        return newPartBudget;
    }
}