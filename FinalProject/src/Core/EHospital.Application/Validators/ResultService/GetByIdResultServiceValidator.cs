using EHospital.Application.Features.Queries.ResultService.GetByIdResultService;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdResultServiceValidator : AbstractValidator<GetByIdResultServiceQueryRequest>
{
    public GetByIdResultServiceValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
