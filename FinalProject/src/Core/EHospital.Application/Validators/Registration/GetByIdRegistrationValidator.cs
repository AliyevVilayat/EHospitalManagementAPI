using EHospital.Application.Features.Queries.Registration.GetByIdRegistration;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdRegistrationValidator:AbstractValidator<GetByIdRegistrationQueryRequest>
{
    public GetByIdRegistrationValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
