using EHospital.Application.Features.Commands.Account.ResetPassword;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ResetPasswordValidator:AbstractValidator<ResetPasswordCommandRequest>
{
    public ResetPasswordValidator()
    {
        RuleFor(r => r.ResetPasswordDTO.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.ResetPasswordDTO.ResetToken)
            .NotNull()
            .NotEmpty().WithMessage("ResetToken deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.ResetPasswordDTO.Password)
            .NotEmpty()
            .NotNull().WithMessage("Password deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250);

        RuleFor(r => r.ResetPasswordDTO.ConfirmPassword)
            .Equal(r => r.ResetPasswordDTO.Password)
            .NotEmpty()
            .NotNull().WithMessage("ConfirmPassword deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(8);

    }
}
