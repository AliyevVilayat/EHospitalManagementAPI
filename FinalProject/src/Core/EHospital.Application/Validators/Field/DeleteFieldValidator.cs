using EHospital.Application.Features.Commands.Field.DeleteField;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteFieldValidator:AbstractValidator<DeleteFieldCommandRequest>
{
    public DeleteFieldValidator()
    {
        RuleFor(f => f.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
