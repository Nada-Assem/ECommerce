using ECommerce.Application.DTOs.CustomerDTO;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                CustomerID = c.CustomerID,
                CustomerName = c.CustomerName,
                CustomerEmail = c.CustomerEmail,
                CustomerPhone = c.CustomerPhone
            }).ToList();
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c == null) return null;

            return new CustomerDto
            {
                CustomerID = c.CustomerID,
                CustomerName = c.CustomerName,
                CustomerEmail = c.CustomerEmail,
                CustomerPhone = c.CustomerPhone
            };
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                CustomerPhone = dto.CustomerPhone
            };

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();

            return new CustomerDto
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CustomerPhone = customer.CustomerPhone
            };
        }
    }
}
