using EHospital.Application.Features.Commands.Service.DeleteInsurance;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteServiceValidator:AbstractValidator<DeleteServiceCommandRequest>
{
    public DeleteServiceValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
