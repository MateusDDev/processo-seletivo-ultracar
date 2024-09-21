using Microsoft.AspNetCore.Mvc;
using Ultracar.Models;

[ApiController]
[Route("[controller]")]
public class BudgetController: ControllerBase
{
    private readonly IBudgetRepository _repository;

    public BudgetController(IBudgetRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetBudgets()
    {
        try
        {
            var budgets = _repository.GetBudgets();
            return Ok(budgets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpPost]
    public IActionResult AddBudget(BudgetDTO budgetDTO)
    {
        try
        {
            var newBudget = _repository.AddBudget(budgetDTO);
            return StatusCode(201, newBudget);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }
}