using EHospital.Application.Features.Commands.ResultService.DeleteResultService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteResultServiceValidator:AbstractValidator<DeleteResultServiceCommandRequest>
{
    public DeleteResultServiceValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
