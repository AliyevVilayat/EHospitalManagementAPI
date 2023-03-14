using EHospital.Application.Features.Queries.Field.GetByIdField;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdFieldValidator:AbstractValidator<GetByIdFieldQueryRequest>
{
    public GetByIdFieldValidator()
    {
        RuleFor(f => f.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
