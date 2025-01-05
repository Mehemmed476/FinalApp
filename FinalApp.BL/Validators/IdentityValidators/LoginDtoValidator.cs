using FinalApp.BL.DTOs.IdentityDTOs;
using FluentValidation;

namespace FinalApp.BL.Validators.IdentityValidators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.UserNameOrEmail).NotEmpty().NotNull().WithMessage("Email or UserName is required.");
        RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password is required.");
    }
}