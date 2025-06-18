using FluentValidation;
using JewelryStore.BLL.DTOs.Product;

namespace JewelryStore.BLL.Validation.Product
{
    public class ProductCreateUpdateDTOValidator : AbstractValidator<ProductCreateUpdateDTO>
    {
        public ProductCreateUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name is required")
                .MaximumLength(300)
                .WithMessage("Product name cannot exceed 300 characters")
                .Matches(@"^[a-zA-Zа-яА-ЯіІїЇєЄґҐ0-9\s\-'"".,()]+$")
                .WithMessage("Product name contains forbidden characters");

            RuleFor(x => x.Weight)
                .NotEmpty()
                .WithMessage("Product weight is required")
                .GreaterThan(0.01m)
                .WithMessage("Product weight must be greater than 0.01")
                .LessThanOrEqualTo(1000m)
                .WithMessage("Product weight cannot exceed 2000 grams");

            RuleFor(x => x.Metal)
                .MaximumLength(50)
                .WithMessage("Metal name cannot exceed 50 characters")
                .Matches(@"^[a-zA-Zа-яА-ЯіІїЇєЄґҐ\s\-]+$")
                .WithMessage("Metal name contains forbidden characters")
                .When(x => !string.IsNullOrEmpty(x.Metal));

            RuleFor(x => x.Stone)
                .MaximumLength(100)
                .WithMessage("Stone name cannot exceed 100 characters")
                .Matches(@"^[a-zA-Zа-яА-ЯіІїЇєЄґҐ\s\-,]+$")
                .WithMessage("Stone name contains forbidden characters")
                .When(x => !string.IsNullOrEmpty(x.Stone));

            RuleFor(x => x.Size)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Size cannot be negative")
                .LessThanOrEqualTo(100)
                .WithMessage("Size cannot exceed 30")
                .When(x => x.Size.HasValue);

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Product price is required")
                .GreaterThan(0)
                .WithMessage("Product price must be greater than 0")
                .LessThanOrEqualTo(100000)
                .WithMessage("Product price cannot exceed 100,000");

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer is required")
                .MaximumLength(100)
                .WithMessage("Manufacturer name cannot exceed 100 characters")
                .Matches(@"^[a-zA-Zа-яА-ЯіІїЇєЄґҐ0-9\s\-'"".,()&]+$")
                .WithMessage("Manufacturer name contains forbidden characters");
        }
    }
}

