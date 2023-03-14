using EHospital.Application.Features.Queries.Role.GetByIdRole;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdRoleValidator : AbstractValidator<GetByIdRoleQueryRequest>
{
    public GetByIdRoleValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
