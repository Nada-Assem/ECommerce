using ECommerce.Application.DTOs.CustomerDTO;
using FluentValidation;

namespace ECommerce.Application.Validators.Customers
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.");

            RuleFor(x => x.CustomerEmail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
