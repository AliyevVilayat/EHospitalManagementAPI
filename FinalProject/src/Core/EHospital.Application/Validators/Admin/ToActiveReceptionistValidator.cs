using EHospital.Application.Features.Commands.Admin.ToActiveReceptionist;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveReceptionistValidator : AbstractValidator<ToActiveReceptionistCommandRequest>
{
    public ToActiveReceptionistValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
