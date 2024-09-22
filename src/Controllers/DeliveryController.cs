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

    [HttpGet("{id}")]
    public IActionResult GetDelivery(int id)
    {
        try
        {
            var delivery = _repository.GetDelivery(id);
            return Ok(delivery);
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
    public async Task<IActionResult> DeliveryPart(DeliveryDTO deliveryDTO)
    {
        try
        {
            var newDelivery = await _repository.DeliveryPart(deliveryDTO);
            return CreatedAtAction(nameof(GetDelivery), new {id = newDelivery.Id}, newDelivery);
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

    [HttpDelete("{id}")]
    public IActionResult DeleteDelivery(int id)
    {
        try
        {
            _repository.DeleteDelivery(id);
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