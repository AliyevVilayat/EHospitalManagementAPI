using EHospital.Application.Features.Commands.Role.CreateRole;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateRoleValidator:AbstractValidator<CreateRoleCommandRequest>
{
    public CreateRoleValidator()
    {
        RuleFor(r => r.RolePostDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
