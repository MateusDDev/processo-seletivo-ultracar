using Microsoft.AspNetCore.Mvc;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

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

    [HttpGet("{id}")]
    public IActionResult GetBudget(int id)
    {
        try
        {
            var budget = _repository.GetBudget(id);
            return Ok(budget);
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
    public IActionResult AddBudget(BudgetDTO budgetDTO)
    {
        try
        {
            var newBudget = _repository.AddBudget(budgetDTO);
            return CreatedAtAction(nameof(GetBudget), new {id = newBudget.Id}, newBudget);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBudget(int id, [FromBody] BudgetDTO budgetDTO)
    {
        try
        {
            var updateBudget = _repository.UpdateBudget(budgetDTO, id);
            return Ok(updateBudget);
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

    [HttpDelete("{id}")]
    public IActionResult DeleteBudget(int id)
    {
        try
        {
            _repository.DeleteBudget(id);
            return NoContent();
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