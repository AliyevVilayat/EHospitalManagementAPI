using EHospital.Application.Features.Commands.Service.UpdateInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateServiceValidator:AbstractValidator<UpdateServiceCommandRequest>
{
    public UpdateServiceValidator()
    {
        RuleFor(s => s.ServicePutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(s => s.ServicePutDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(s => s.ServicePutDTO.FieldIdStr)
            .NotNull()
            .NotEmpty().WithMessage("FieldIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(s => s.ServicePutDTO.Cost)
            .NotNull()
            .NotEmpty().WithMessage("Cost deyeri bos ve ya null deyer ala bilmez")
            .GreaterThan(-1).WithMessage("Cost menfi ola bilmez");
    }
}
