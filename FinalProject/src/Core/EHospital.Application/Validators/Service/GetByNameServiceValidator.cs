using EHospital.Application.Features.Queries.Service.GetByNameService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNameServiceValidator:AbstractValidator<GetByNameServiceQueryRequest>
{
    public GetByNameServiceValidator()
    {
        RuleFor(s => s.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
