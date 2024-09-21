using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ultracar.Models;

public class PartBudget
{
    public int Id {get; set;}
    
    public int PartId {get; set;}
    public Part Part {get; set;} = null!;

    public int BudgetId {get; set;}
    public Budget Budget {get; set;} = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PartBudgetStatus Status {get; set;}
}

public class PartBudgetDTO
{
    [Required]
    public int PartId {get; set;}

    [Required]
    public int BudgetId {get; set;}
}

public enum PartBudgetStatus
{
    Pending,
    Delivered
}