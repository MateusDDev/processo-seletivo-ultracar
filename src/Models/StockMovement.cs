using System.Text.Json.Serialization;

namespace Ultracar.Models;

public class StockMovement
{
    public int Id {get; set;}
    public int Quantity {get; set;}
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StockMovementType Type {get; set;}
    public DateTime MovementDate {get; set;}

    public int PartId {get; set;}

    [JsonIgnore]
    public Part Part {get; set;} = null!;
}

public enum StockMovementType
{
    Entry,
    Exit
}