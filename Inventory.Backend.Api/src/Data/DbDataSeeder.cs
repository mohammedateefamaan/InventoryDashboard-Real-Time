using Inventory.Backend.Api.src.Models;

namespace Inventory.Backend.Api.src.Data;

public static class DbDataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.InventoryItems.Any())
            return;

        context.InventoryItems.AddRange(
            new InventoryItem { ProductName = "Laptop", Quantity = 100, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Desktop Computer", Quantity = 60, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Smartphone", Quantity = 200, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Tablet", Quantity = 120, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Smart Watch", Quantity = 90, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Wireless Mouse", Quantity = 250, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Mechanical Keyboard", Quantity = 180, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Gaming Monitor", Quantity = 75, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "External Hard Drive", Quantity = 140, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "USB Flash Drive", Quantity = 500, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "SSD Drive", Quantity = 160, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Graphics Card", Quantity = 45, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Motherboard", Quantity = 55, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Power Supply Unit", Quantity = 85, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "CPU Processor", Quantity = 70, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "RAM Module", Quantity = 300, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Webcam", Quantity = 110, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Bluetooth Speaker", Quantity = 130, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Noise Cancelling Headphones", Quantity = 95, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Wireless Earbuds", Quantity = 220, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Router", Quantity = 80, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "WiFi Extender", Quantity = 65, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Network Switch", Quantity = 50, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Printer", Quantity = 40, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Scanner", Quantity = 35, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Projector", Quantity = 25, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "UPS Battery Backup", Quantity = 45, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Smart TV", Quantity = 55, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "Game Console", Quantity = 60, LastUpdated = DateTime.UtcNow },
            new InventoryItem { ProductName = "VR Headset", Quantity = 30, LastUpdated = DateTime.UtcNow }
        );

        context.SaveChanges();
    }
}
