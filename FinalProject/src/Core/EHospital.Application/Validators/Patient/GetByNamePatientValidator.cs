using EHospital.Application.Features.Queries.Patient.GetByNamePatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNamePatientValidator : AbstractValidator<GetByNamePatientQueryRequest>
{
    public GetByNamePatientValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
