using EHospital.Application.Features.Commands.Service.CreateInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateServiceValidator:AbstractValidator<CreateServiceCommandRequest>
{
    public CreateServiceValidator()
    {
        RuleFor(s => s.ServicePostDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(s => s.ServicePostDTO.FieldIdStr)
            .NotNull()
            .NotEmpty().WithMessage("FieldIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(s => s.ServicePostDTO.Cost)
            .NotNull()
            .NotEmpty().WithMessage("Cost deyeri bos ve ya null deyer ala bilmez")
            .GreaterThan(-1).WithMessage("Cost menfi ola bilmez");
    }
}
