using EHospital.Application.Features.Queries.Service.GetByIdService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdServiceValidator:AbstractValidator<GetByIdServiceQueryRequest>
{
    public GetByIdServiceValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
