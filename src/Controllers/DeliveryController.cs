using Microsoft.AspNetCore.Mvc;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

[ApiController]
[Route("[controller]")]
public class DeliveryController: ControllerBase
{
    private readonly IDeliveryRepository _repository;

    public DeliveryController(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetDeliveries()
    {
        try
        {
            var deliveries = _repository.GetDeliveries();
            return Ok(deliveries);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeliveryPart(DeliveryDTO deliveryDTO)
    {
        try
        {
            var newDelivery = await _repository.DeliveryPart(deliveryDTO.PartBudgetId, deliveryDTO.Cep);
            return StatusCode(201, newDelivery);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new {ex.Message});
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new {ex.Message});
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }
}