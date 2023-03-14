using EHospital.Application.Features.Commands.Field.CreateField;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateFieldValidator : AbstractValidator<CreateFieldCommandRequest>
{
    public CreateFieldValidator()
    {
        RuleFor(f => f.FieldPostDTO.PersonField)
            .NotNull()
            .NotEmpty().WithMessage("PersonField deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("PersonField deyeri 50 simvoldan artiq ola bilmez");
    }
}
