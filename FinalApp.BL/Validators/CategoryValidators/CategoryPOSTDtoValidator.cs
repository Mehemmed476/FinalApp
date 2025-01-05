using FinalApp.BL.DTOs.CategoryDTOs;
using FluentValidation;

namespace FinalApp.BL.Validators.CategoryValidators;

public class CategoryPOSTDtoValidator : AbstractValidator<CategoryPOSTDto>
{
    public CategoryPOSTDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().NotEmpty().WithMessage("Title cannot be empty.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotNull().NotEmpty().WithMessage("Description cannot be empty.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}