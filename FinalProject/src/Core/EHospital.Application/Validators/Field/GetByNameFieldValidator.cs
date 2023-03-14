using EHospital.Application.Features.Queries.Field.GetByNameField;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNameFieldValidator : AbstractValidator<GetByNameFieldQueryRequest>
{
    public GetByNameFieldValidator()
    {
        RuleFor(d => d.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
