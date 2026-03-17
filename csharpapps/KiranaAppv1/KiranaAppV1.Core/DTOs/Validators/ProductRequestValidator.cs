namespace KiranaAppV1.Core.DTOs.Validators;

using FluentValidation;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.Entities;

public class ProductRequestValidator: AbstractValidator<ProductRequestDTO>
{
    public ProductRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Product Name cannot be Empty")
        .MinimumLength(3).WithMessage("Name must be atleast 3 characters")
        .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

        RuleFor(x => x.Price)
        .GreaterThan(0).WithMessage("Price must be greater than zero.")
        .LessThan(10000000).WithMessage("Price is suspiciously High");

        // Custom Validation
        RuleFor(x=>x.Name)
        .Must(name => !name.Contains("forbidden"))
        .WithMessage("Name contains Illegal words");

        RuleFor(x=> x.Category)
        .IsEnumName(typeof(ProductCategory), caseSensitive: false)
        .WithMessage("Invalid Category. Can be only FRESH, PACKAGED, SNACKS, FROZEN");

    }
}