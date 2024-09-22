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

    [HttpGet("{id}")]
    public IActionResult GetPartBudget(int id)
    {
        try
        {
            var partBudget = _repository.GetPartBudget(id);
            return Ok(partBudget);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new {ex.Message});
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpPost]
    public IActionResult AddPartToBudget(PartBudgetDTO partBudgetDTO)
    {
        try
        {
            var newPartBudget = _repository.AddPartToBudget(partBudgetDTO);
            return CreatedAtAction(nameof(GetPartBudget), new {id = newPartBudget.Id}, newPartBudget);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new {ex.Message});
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

}