using ECommerce.Application.DTOs.OrderDTO;
using ECommerce.Application.Validators.Products;
using FluentValidation;

namespace ECommerce.Application.Validators.Orders
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerID)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("At least one product must be added to the order.");

            RuleForEach(x => x.Products).SetValidator(new ProductOrderValidator());
        }
    }
}
