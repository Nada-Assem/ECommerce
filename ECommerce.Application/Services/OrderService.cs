using ECommerce.Application.DTOs.Common;
using ECommerce.Application.DTOs.OrderDTO;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IProductRepository _productRepo;

        public OrderService(
            IOrderRepository orderRepo,
            ICustomerRepository customerRepo,
            IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _productRepo = productRepo;
        }

        public async Task<OperationResult<OrderDto>> CreateOrderAsync(CreateOrderDto dto)
        {
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerID);
            if (customer == null)
                return OperationResult<OrderDto>.Fail("Customer not found");

            var productIds = dto.Products.Select(p => p.ProductID).ToList();
            var products = await _productRepo.GetByIdsAsync(productIds);

            if (products.Count != dto.Products.Count)
                return OperationResult<OrderDto>.Fail("Some products not found");

            foreach (var prodDto in dto.Products)
            {
                var product = products.First(p => p.ProductID == prodDto.ProductID);
                if (product.Stock < prodDto.Quantity)
                    return OperationResult<OrderDto>.Fail($"Product '{product.ProductName}' does not have enough stock");

                product.Stock -= prodDto.Quantity;
                await _productRepo.UpdateAsync(product);
            }

            var order = new Order
            {
                CustomerID = customer.CustomerID,
                OrderDate = DateTime.UtcNow,
                StatusID = (int)OrderStatusEnum.Pending ,
                TotalPrice = dto.Products.Sum(p =>
                {
                    var product = products.First(pr => pr.ProductID == p.ProductID);
                    return product.ProductPrice * p.Quantity;
                })
            };

            var productDict = products.ToDictionary(p => p.ProductID);

            foreach (var prodDto in dto.Products)
            {
                var product = productDict[prodDto.ProductID];
                order.Items.Add(new OrderItem
                {
                    ProductID = prodDto.ProductID,
                    Quantity = prodDto.Quantity,
                    UnitPrice = product.ProductPrice
                });
            }

            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveChangesAsync();

            var orderDto = new OrderDto
            {
                OrderID = order.OrderID,
                CustomerName = customer.CustomerName,
                Status = OrderStatusEnum.Pending.ToString() ,
                NumberOfProducts = order.Items.Count,
                TotalPrice = order.TotalPrice
            };

            return OperationResult<OrderDto>.Success(orderDto);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null) return null;

            return new OrderDto
            {
                OrderID = order.OrderID,
                CustomerName = order.Customer.CustomerName,
                Status = order.Status.StatusName,
                NumberOfProducts = order.Items.Count,
                TotalPrice = order.TotalPrice
            };
        }

        public async Task<bool> UpdateOrderStatusToDeliveredAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null) return false;

            order.StatusID = (int)OrderStatusEnum.Completed  ;
            await _orderRepo.SaveChangesAsync();
            return true;
        }
    }

}
