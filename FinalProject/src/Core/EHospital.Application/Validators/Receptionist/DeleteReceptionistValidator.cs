using EHospital.Application.Features.Commands.Receptionist.DeleteReceptionist;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteReceptionistValidator:AbstractValidator<DeleteReceptionistCommandRequest>
{
    public DeleteReceptionistValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
