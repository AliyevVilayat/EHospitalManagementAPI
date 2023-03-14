using EHospital.Application.Features.Commands.Admin.ToActiveUser;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveUserValidator : AbstractValidator<ToActiveUserCommandRequest>
{
    public ToActiveUserValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
