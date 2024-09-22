using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ultracar.Models;

public class PartBudget
{
    public int Id {get; set;}
    
    [JsonIgnore]
    public int PartId {get; set;}
    public Part Part {get; set;} = null!;

    [JsonIgnore]
    public int BudgetId {get; set;}
    public Budget Budget {get; set;} = null!;

    public int PartQuantity {get; set;}

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PartBudgetStatus Status {get; set;}
}

public class PartBudgetDTO
{
    [Required]
    public int PartId {get; set;}

    [Required]
    public int BudgetId {get; set;}

    [Required]
    [Range(1, 999, ErrorMessage = "A quantidade precisa ser maior que 1")]
    public int PartQuantity {get; set;}
}

public enum PartBudgetStatus
{
    Pending,
    Delivered
}