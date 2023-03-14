using EHospital.Application.Features.Queries.Insurance.GetByIdInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdInsuranceValidator : AbstractValidator<GetByIdInsuranceQueryRequest>
{
    public GetByIdInsuranceValidator()
    {

        RuleFor(i => i.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
