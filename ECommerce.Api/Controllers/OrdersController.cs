using ECommerce.Application.DTOs.OrderDTO;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Interfaces.Services;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            var result = await _service.CreateOrderAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            var locationUri = Url.Action(nameof(GetById), new { id = result.Data!.OrderID });
            return Created(locationUri!, result.Data);
        }

        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null) return NotFound(new { message = "Order not found" });
            return Ok(order);
        }

        [HttpPost("UpdateOrderStatus")]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            var updated = await _service.UpdateOrderStatusToDeliveredAsync(id);
            if (!updated) return NotFound(new { message = "Order not found" });
            return Ok(new { message = "Order status updated to Delivered" });
        }
    }
}
