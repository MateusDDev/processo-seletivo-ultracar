namespace Ultracar.Models;

public class Part
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public int Stock {get; set;}

    public ICollection<PartBudget> PartBudgets {get; set;}
}