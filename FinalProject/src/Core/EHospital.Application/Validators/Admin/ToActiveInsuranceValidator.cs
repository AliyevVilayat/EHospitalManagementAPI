using EHospital.Application.Features.Commands.Admin.ToActiveInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveInsuranceValidator : AbstractValidator<ToActiveInsuranceCommandRequest>
{
    public ToActiveInsuranceValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
