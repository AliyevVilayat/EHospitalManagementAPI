using EHospital.Application.Features.Commands.Insurance.CreateInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateInsuranceValidator : AbstractValidator<CreateInsuranceCommandRequest>
{
    public CreateInsuranceValidator()
    {
        RuleFor(i => i.InsurancePostDTO.PersonInsurance)
            .NotNull()
            .NotEmpty().WithMessage("PersonInsurance deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("PersonInsurance deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(i => i.InsurancePostDTO.Discount)
            .NotNull()
            .NotEmpty().WithMessage("Discount deyeri bos ve ya null deyer ala bilmez")
            .GreaterThan(-1).WithMessage("Discount menfi ola bilmez")
            .LessThanOrEqualTo(100).WithMessage("Discount 100 den boyuk ola bilmez");
    }
}
