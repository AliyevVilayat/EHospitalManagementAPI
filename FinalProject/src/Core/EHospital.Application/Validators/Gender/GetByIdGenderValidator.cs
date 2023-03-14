using EHospital.Application.Features.Queries.Gender.GetByIdGender;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdGenderValidator:AbstractValidator<GetByIdGenderQueryRequest>
{
    public GetByIdGenderValidator()
    {
        RuleFor(g => g.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
