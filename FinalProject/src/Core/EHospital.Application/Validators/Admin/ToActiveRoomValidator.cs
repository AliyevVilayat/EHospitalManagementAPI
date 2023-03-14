using EHospital.Application.Features.Commands.Admin.ToActiveRoom;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveRoomValidator : AbstractValidator<ToActiveRoomCommandRequest>
{
    public ToActiveRoomValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
