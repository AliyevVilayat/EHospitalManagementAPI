using EHospital.Application.Features.Commands.Account.ForgotPassword;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ForgotPasswordValidator:AbstractValidator<ForgotPasswordCommandRequest>
{
    public ForgotPasswordValidator()
    {
        RuleFor(f => f.Email)
            .NotEmpty()
            .NotNull().WithMessage("Email deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(5);
    }
}
