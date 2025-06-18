using FluentValidation;
using JewelryStore.BLL.DTOs.Order;

namespace JewelryStore.BLL.Validation.Order
{
    public class OrderCreateDTOValidator : AbstractValidator<OrderCreateDTO>
    {
        public OrderCreateDTOValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is required")
                .GreaterThan(0)
                .WithMessage("Product ID must be greater than 0");

            RuleFor(x => x.ClientId)
                .NotEmpty()
                .WithMessage("Client ID is required")
                .GreaterThan(0)
                .WithMessage("Client ID must be greater than 0");
        }
    }
}

