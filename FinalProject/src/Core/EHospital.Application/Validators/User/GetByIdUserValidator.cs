using EHospital.Application.Features.Queries.User.GetByIdUser;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdUserValidator:AbstractValidator<GetByIdUserQueryRequest>
{
    public GetByIdUserValidator()
    {
        RuleFor(u => u.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
