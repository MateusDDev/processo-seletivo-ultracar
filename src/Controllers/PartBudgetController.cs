using Microsoft.AspNetCore.Mvc;
using Ultracar.Repositories.Interfaces;

[ApiController]
[Route("[controller]")]
public class PartBudgetController: ControllerBase
{
    private readonly IPartBudgetRepository _repository;

    public PartBudgetController(IPartBudgetRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("{budgetId}/parts/{partId}")]
    public IActionResult AddPartBudget(int budgetId, int partId)
    {
        var newPartBudget = _repository.AddPartToBudget(budgetId, partId);
        return Ok(newPartBudget);
    }

}