namespace Ultracar.Models;

public class PartBudget
{
    public int Id {get; set;}

    public int PartId {get; set;}
    public Part Part {get; set;}

    public int BudgetId {get; set;}
    public Budget Budget {get; set;}

    public string Status {get; set;} = "Pending";
}