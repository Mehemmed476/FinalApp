using FinalApp.BL.DTOs.ProductDTOs;
using FluentValidation;

namespace FinalApp.BL.Validators.ProductValidators;

public class ProductGETDtoValidator : AbstractValidator<ProductGETDto>
{
    public ProductGETDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId must be a positive integer.");

        RuleFor(x => x.Colors)
            .Must(colors => colors == null || colors.Any())
            .WithMessage("Colors collection cannot be empty if assigned.");

        RuleFor(x => x.Sizes)
            .Must(sizes => sizes == null || sizes.Any())
            .WithMessage("Sizes collection cannot be empty if assigned.");
    }
}