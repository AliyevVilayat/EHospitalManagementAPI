using EHospital.Application.Features.Commands.Admin.ToActivePatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActivePatientValidator : AbstractValidator<ToActivePatientCommandRequest>
{
    public ToActivePatientValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
