namespace Ultracar.Models;

public class StockMovement
{
    public int Id {get; set;}
    public int QuantityMoved {get; set;}
    public string Type {get; set;} = null!;

    public int PartId {get; set;}
    public Part Part {get; set;} = null!;
}