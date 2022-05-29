using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using MyAPI.Service;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _ordersService;

    public OrderController(OrderService ordersService) =>
        _ordersService = ordersService;

    [HttpGet]
    public async Task<List<Order>> Get() =>
        await _ordersService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Order>> Get(string id)
    {
        var order = await _ordersService.GetAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Order newOrder)
    {
        await _ordersService.CreateAsync(newOrder);

        return CreatedAtAction(nameof(Get), new { id = newOrder.Id }, newOrder);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Order updateOrder)
    {
        var order = await _ordersService.GetAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        updateOrder.Id = order.Id;

        await _ordersService.UpdateAsync(id, updateOrder);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var order = await _ordersService.GetAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        await _ordersService.RemoveAsync(id);

        return NoContent();
    }
}