using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ultracar.Models;

public class Delivery
{
    public int Id {get; set;}
    public string Address {get; set;} = null!;

    public int PartBudgetId {get; set;}
    [JsonIgnore]
    public PartBudget PartBudget {get; set;} = null!;
}

public class DeliveryDTO
{
    [Required]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP precisa conter 8 dígitos númericos")]
    public string Cep { get; set; } = null!;

    [Required]
    public int PartBudgetId { get; set; }
}

