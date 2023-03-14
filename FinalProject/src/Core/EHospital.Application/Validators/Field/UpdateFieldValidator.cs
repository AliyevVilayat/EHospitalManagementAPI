using EHospital.Application.Features.Commands.Field.UpdateField;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateFieldValidator:AbstractValidator<UpdateFieldCommandRequest>
{
    public UpdateFieldValidator()
    {
        RuleFor(p => p.FieldPutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(f => f.FieldPutDTO.PersonField)
            .NotNull()
            .NotEmpty().WithMessage("PersonField deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("PersonField deyeri 50 simvoldan artiq ola bilmez");
    }
}
