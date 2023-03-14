using EHospital.Application.Features.Commands.User.DeleteUser;
using FluentValidation;

namespace EHospital.Application.Validators.User;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(u => u.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
