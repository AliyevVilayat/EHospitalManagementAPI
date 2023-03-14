using EHospital.Application.Features.Commands.Patient.DeletePatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeletePatientValidator : AbstractValidator<DeletePatientCommandRequest>
{
    public DeletePatientValidator()
    {
        RuleFor(p=>p.Id)
            .NotNull()
            .NotEmpty().WithMessage("ID deyeri bos ve ya null deyer ala bilmez");
    }
}
