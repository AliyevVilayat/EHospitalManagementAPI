using EHospital.Application.Features.Commands.Role.UpdateRole;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateRoleValidator:AbstractValidator<UpdateRoleCommandRequest>
{
    public UpdateRoleValidator()
    {
        RuleFor(r => r.RolePutDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(r => r.RolePutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
