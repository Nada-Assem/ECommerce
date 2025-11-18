using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.OrderDTO;
using ECommerce.Application.Validators.Products;

namespace ECommerce.Application.Validators.Products
{
    public class ProductOrderValidator : AbstractValidator<OrderProductDto>
    {
        public ProductOrderValidator()
        {
            RuleFor(p => p.ProductID)
                .GreaterThan(0).WithMessage("ProductID must be greater than 0.");

            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("Product quantity must be at least 1.");
        }
    }
}
