using ECommerce.Application.DTOs.CustomerDTO;
using ECommerce.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("GetCustomerByID")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound(new { message = "Customer not found" });
            return Ok(customer);
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> Create(CreateCustomerDto input)
        {
            var createdCustomer = await _service.CreateCustomerAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.CustomerID }, createdCustomer);
        }
    }
}
