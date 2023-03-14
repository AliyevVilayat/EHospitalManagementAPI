using EHospital.Application.Features.Commands.Registration.DeleteRegistration;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteRegistrationValidator:AbstractValidator<DeleteRegistrationCommandRequest>
{
    public DeleteRegistrationValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
