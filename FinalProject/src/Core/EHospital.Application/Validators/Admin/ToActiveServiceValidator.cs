using EHospital.Application.Features.Commands.Admin.ToActiveService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveServiceValidator : AbstractValidator<ToActiveServiceCommandRequest>
{
    public ToActiveServiceValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
