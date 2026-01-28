using Inventory.Backend.Api.src.Data;
using Inventory.Backend.Api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Backend.Api.src.Services;

public class InventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryItem>> GetAllAsync()
    {
        return await _context.InventoryItems.AsNoTracking().ToListAsync();
    }

    public async Task<InventoryItem?> UpdateStockAsync(int id, int quantity)
    {
        var item = await _context.InventoryItems.FindAsync(id);
        if (item == null) return null;

        item.Quantity = quantity;
        item.LastUpdated = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return item;
    }
}
