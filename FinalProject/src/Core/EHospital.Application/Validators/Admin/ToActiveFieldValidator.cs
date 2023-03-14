using EHospital.Application.Features.Commands.Admin.ToActiveField;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveFieldValidator : AbstractValidator<ToActiveFieldCommandRequest>
{
    public ToActiveFieldValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
