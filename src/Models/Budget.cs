namespace Ultracar.Models;

public class Budget
{
    public int Id {get; set;}
    public int Number {get; set;}
    public string VehiclePlate {get; set;} = null!;
    public string ClientName {get; set;} = null!;

    public ICollection<PartBudget> PartBudgets {get; set;}
}