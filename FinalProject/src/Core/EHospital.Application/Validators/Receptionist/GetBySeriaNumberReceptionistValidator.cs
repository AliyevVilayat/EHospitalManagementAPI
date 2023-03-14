using EHospital.Application.Features.Queries.Receptionist.GetByNameReceptionist;
using EHospital.Application.Features.Queries.Receptionist.GetBySeriaNumberReceptionist;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetBySeriaNumberReceptionistValidator : AbstractValidator<GetBySeriaNumberReceptionistQueryRequest>
{
    public GetBySeriaNumberReceptionistValidator()
    {
        RuleFor(r => r.SeriaNumber)
            .NotNull()
            .NotEmpty().WithMessage("SeriaNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("SeriaNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(11).WithMessage("SeriaNumber deyeri 11 simvoldan artiq ola bilmez");
    }
}
