using Microsoft.AspNetCore.Mvc;
using Ultracar.Models;
using Ultracar.Repositories.Interfaces;

[ApiController]
[Route("[controller]")]
public class PartController: ControllerBase
{
    private readonly IPartRepository _repository;

    public PartController(IPartRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetParts()
    {
        try
        {
            var parts = _repository.GetParts();
            return Ok(parts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPart(int id)
    {
        try
        {
            var part = _repository.GetPart(id);
            return Ok(part);
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
    public IActionResult AddPart(PartDTO partDTO)
    {
        try
        {
            var newPart = _repository.AddPart(partDTO);
            return CreatedAtAction(nameof(GetPart), new {id = newPart.Id}, newPart);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePart(int id, [FromBody] PartDTO partDTO)
    {
        try
        {
            var newPart = _repository.UpdatePart(partDTO, id);
            return CreatedAtAction(nameof(GetPart), new {id = newPart.Id}, newPart);
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
    public IActionResult DeletePart(int id)
    {
        try
        {
            _repository.DeletePart(id);
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