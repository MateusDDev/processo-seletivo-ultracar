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

    [HttpPost]
    public IActionResult AddPart(PartDTO partDTO)
    {
        try
        {
            var newPart = _repository.AddPart(partDTO);
            return StatusCode(201, newPart);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {ex.Message});
        }
    }
}