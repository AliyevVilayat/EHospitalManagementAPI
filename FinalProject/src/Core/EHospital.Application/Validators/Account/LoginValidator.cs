using EHospital.Application.Features.Commands.Account.Login;
using FluentValidation;

namespace EHospital.Application.Validators;

public class LoginValidator:AbstractValidator<LoginCommandRequest>
{
    public LoginValidator()
    {
        RuleFor(l => l.LoginDTO.UsernameOrEmail)
            .NotEmpty()
            .NotNull().WithMessage("UsernameOrEmail deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(5);

        RuleFor(u => u.LoginDTO.Password)
            .NotEmpty()
            .NotNull().WithMessage("Password deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250);
    }
}
