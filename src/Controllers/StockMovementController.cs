using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StockMovementController: ControllerBase
{
    private readonly IStockMovementsRepository _repository;

    public StockMovementController(IStockMovementsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetStockMovements()
    {
        try
        {
            var movements = _repository.GetStockMovements();
            return Ok(movements);
        }
        catch (Exception ex) 
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpGet("{partId}")]
    public IActionResult GetStockMovements(int partId)
    {
        try
        {
            var movements = _repository.GetStockMovementsByPartId(partId);
            return Ok(movements);
        }
        catch (Exception ex) 
        {
            return StatusCode(500, new {ex.Message});
        }
    }
}