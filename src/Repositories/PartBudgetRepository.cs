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

    public PartBudget AddPartToBudget(PartBudgetDTO partBudgetDTO)
    {
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