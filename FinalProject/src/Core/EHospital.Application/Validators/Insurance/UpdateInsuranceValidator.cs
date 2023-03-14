using EHospital.Application.Features.Commands.Insurance.UpdateInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateInsuranceValidator:AbstractValidator<UpdateInsuranceCommandRequest>
{
    public UpdateInsuranceValidator()
    {
        RuleFor(i => i.InsurancePutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(i => i.InsurancePutDTO.PersonInsurance)
            .NotNull()
            .NotEmpty().WithMessage("PersonInsurance deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("PersonInsurance deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(i => i.InsurancePutDTO.Discount)
            .NotNull()
            .NotEmpty().WithMessage("Discount deyeri bos ve ya null deyer ala bilmez")
            .GreaterThan(-1).WithMessage("Discount menfi ola bilmez")
            .LessThanOrEqualTo(100).WithMessage("Discount 100 den boyuk ola bilmez");
    }
}
