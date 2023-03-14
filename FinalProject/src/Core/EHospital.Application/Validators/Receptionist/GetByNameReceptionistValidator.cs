using EHospital.Application.Features.Queries.Receptionist.GetByNameReceptionist;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNameReceptionistValidator:AbstractValidator<GetByNameReceptionistQueryRequest>
{
    public GetByNameReceptionistValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
