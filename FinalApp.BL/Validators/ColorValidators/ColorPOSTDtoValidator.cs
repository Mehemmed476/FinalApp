using FinalApp.BL.DTOs.ColorDTOs;
using FluentValidation;

namespace FinalApp.BL.Validators.ColorValidators;

public class ColorPOSTDtoValidator : AbstractValidator<ColorPOSTDto>
{
    public ColorPOSTDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

        RuleFor(x => x.HexCode)
            .NotEmpty().WithMessage("HexCode cannot be empty.")
            .Matches("^#[0-9A-Fa-f]{6}$").WithMessage("HexCode must be a valid hex color code (e.g., #FFFFFF).");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be a positive integer.");
    }
}