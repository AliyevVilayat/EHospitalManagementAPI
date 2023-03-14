using EHospital.Application.Features.Commands.Role.DeleteRole;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteRoleValidator:AbstractValidator<DeleteRoleCommandRequest>
{
    public DeleteRoleValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
