using EHospital.Application.Features.Queries.Insurance.GetByNameInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNameInsuranceValidator : AbstractValidator<GetByNameInsuranceQueryRequest>
{
    public GetByNameInsuranceValidator()
    {
        RuleFor(i => i.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
