using EHospital.Application.Features.Queries.User.GetByUserNameUser;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByUserNameUserValidator : AbstractValidator<GetByUserNameUserQueryRequest>
{
    public GetByUserNameUserValidator()
    {
        RuleFor(u => u.UserName)
            .NotNull()
            .NotEmpty().WithMessage("UserName deyeri bos ve ya null deyer ala bilmez");
    }
}
