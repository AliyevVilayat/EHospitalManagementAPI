using EHospital.Application.Features.Commands.ResultService.UpdateResultService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateResultServiceValidator:AbstractValidator<UpdateResultServiceCommandRequest>
{
    public UpdateResultServiceValidator()
    {
        RuleFor(r => r.ResultServicePutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.ResultServicePutDTO.Result)
            .NotNull()
            .NotEmpty().WithMessage("Result deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(150).WithMessage("Result deyeri 150 simvoldan artiq ola bilmez");

        RuleFor(r => r.ResultServicePutDTO.RegistrationIdStr)
            .NotNull()
            .NotEmpty().WithMessage("RegistrationIdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
