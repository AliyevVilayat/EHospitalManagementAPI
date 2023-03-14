using EHospital.Application.Features.Queries.BloodGroup.GetByIdBloodGroup;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdBloodGroupValidator:AbstractValidator<GetByIdBloodGroupQueryRequest>
{
    public GetByIdBloodGroupValidator()
    {
        RuleFor(b => b.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
