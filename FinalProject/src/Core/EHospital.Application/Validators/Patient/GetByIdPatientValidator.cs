using EHospital.Application.Features.Queries.Patient.GetByIdPatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdPatientValidator:AbstractValidator<GetByIdPatientQueryRequest>
{
    public GetByIdPatientValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
