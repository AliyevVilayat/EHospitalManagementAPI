using EHospital.Application.Features.Commands.Insurance.DeleteInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteInsuranceValidator:AbstractValidator<DeleteInsuranceCommandRequest>
{
    public DeleteInsuranceValidator()
    {
        RuleFor(i => i.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
