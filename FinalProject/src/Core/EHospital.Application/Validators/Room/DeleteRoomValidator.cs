using EHospital.Application.Features.Commands.Room.DeleteRoom;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteRoomValidator:AbstractValidator<DeleteRoomCommandRequest>
{
    public DeleteRoomValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
