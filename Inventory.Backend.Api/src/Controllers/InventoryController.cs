using Inventory.Backend.Api.src.Hubs;
using Inventory.Backend.Api.src.Models;
using Inventory.Backend.Api.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Inventory.Backend.Api.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _service;
    private readonly IHubContext<InventoryHub> _hub;

    public InventoryController(
        InventoryService service,
        IHubContext<InventoryHub> hub)
    {
        _service = service;
        _hub = hub;
    }

    [HttpGet]
    public async Task<IActionResult> GetInventory()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateStock([FromQuery] int id, [FromQuery] int quantity)
    {
        InventoryItem? item = await _service.UpdateStockAsync(id, quantity);

        if (item is null) 
        return NotFound();

        await _hub.Clients.All.SendAsync("StockUpdated", item);

        return Ok(item);
    }
}
