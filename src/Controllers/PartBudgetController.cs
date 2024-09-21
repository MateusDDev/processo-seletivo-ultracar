using Microsoft.AspNetCore.Mvc;
using Ultracar.Models;
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

    [HttpGet]
    public IActionResult GetPartBudgets()
    {
        try
        {
            var partBudgets = _repository.GetPartBudgets();
            return Ok(partBudgets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpPost]
    public IActionResult AddPartBudget(PartBudgetDTO partBudgetDTO)
    {
        try
        {
            var newPartBudget = _repository.AddPartToBudget(partBudgetDTO);
            return StatusCode(201, newPartBudget);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

}