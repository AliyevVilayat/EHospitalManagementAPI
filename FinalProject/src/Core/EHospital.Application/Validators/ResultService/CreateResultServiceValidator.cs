using EHospital.Application.Features.Commands.ResultService.CreateResultService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateResultServiceValidator:AbstractValidator<CreateResultServiceCommandRequest>
{
    public CreateResultServiceValidator()
    {
        RuleFor(r => r.ResultServicePostDTO.Result)
            .NotNull()
            .NotEmpty().WithMessage("Result deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(150).WithMessage("Result deyeri 150 simvoldan artiq ola bilmez");

        RuleFor(r => r.ResultServicePostDTO.RegistrationIdStr)
            .NotNull()
            .NotEmpty().WithMessage("RegistrationIdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
