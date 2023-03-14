using EHospital.Application.Features.Queries.Role.GetByNameRole;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNameRoleValidator:AbstractValidator<GetByNameRoleQueryRequest>
{
    public GetByNameRoleValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez");
    }
}
