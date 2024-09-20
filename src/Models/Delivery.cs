namespace Ultracar.Models;

public class Delivery
{
    public int Id {get; set;}
    public string Address {get; set;}

    public int BudgetId {get; set;}
    public Budget Budget {get; set;}
}
