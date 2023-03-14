using EHospital.Application.Features.Commands.Account.VerifyResetToken;
using FluentValidation;

namespace EHospital.Application.Validators;

public class VerifyResetTokenValidator : AbstractValidator<VerifyResetTokenCommandRequest>
{
    public VerifyResetTokenValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty()
            .NotNull().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");

        RuleFor(v => v.ResetToken)
           .NotEmpty()
           .NotNull().WithMessage("ResetToken deyeri bos ve ya null deyer ala bilmez");
    }
}
