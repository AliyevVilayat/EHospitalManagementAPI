using EHospital.Application.Features.Queries.Receptionist.GetByIdReceptionist;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdReceptionistValidator:AbstractValidator<GetByIdReceptionistQueryRequest>
{
    public GetByIdReceptionistValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
