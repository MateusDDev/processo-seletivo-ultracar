using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ultracar.Models;

public class Part
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public int Stock {get; set;}

    [JsonIgnore]
    public ICollection<PartBudget> PartBudgets {get; set;} = null!;

    [JsonIgnore]
    public ICollection<StockMovement> StockMovements {get; set;} = null!;
}

public class PartDTO
{
    [Required]
    public string Name {get; set;} = null!;

    [Required]
    public int Stock {get; set;}
}