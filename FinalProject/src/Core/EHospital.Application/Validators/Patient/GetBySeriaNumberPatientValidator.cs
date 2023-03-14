using EHospital.Application.Features.Queries.Patient.GetBySeriaNumberPatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetBySeriaNumberPatientValidator : AbstractValidator<GetBySeriaNumberPatientQueryRequest>
{
    public GetBySeriaNumberPatientValidator()
    {
        RuleFor(p => p.SeriaNumber)
            .NotNull()
            .NotEmpty().WithMessage("SeriaNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("SeriaNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(11).WithMessage("SeriaNumber deyeri 11 simvoldan artiq ola bilmez");
    }
}
