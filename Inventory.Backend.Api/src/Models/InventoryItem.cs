namespace Inventory.Backend.Api.src.Models;

public class InventoryItem
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public DateTime LastUpdated { get; set; }
}
