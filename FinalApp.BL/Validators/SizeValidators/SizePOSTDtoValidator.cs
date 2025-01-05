using FinalApp.BL.DTOs.SizeDTOs;
using FluentValidation;

namespace FinalApp.BL.Validators.SizeValidators;

public class SizePOSTDtoValidator : AbstractValidator<SizePOSTDto>
{
    public SizePOSTDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");
        
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be a positive integer.");
    }
}