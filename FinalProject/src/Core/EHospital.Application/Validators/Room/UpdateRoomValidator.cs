using EHospital.Application.Features.Commands.Room.UpdateRoom;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateRoomValidator:AbstractValidator<UpdateRoomCommandRequest>
{
    public UpdateRoomValidator()
    {
        RuleFor(r => r.RoomPutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RoomPutDTO.RoomCode)
            .NotNull()
            .NotEmpty().WithMessage("RoomCode deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(16).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(r => r.RoomPutDTO.Floor)
            .NotNull()
            .NotEmpty().WithMessage("Floor deyeri bos ve ya null deyer ala bilmez")
            .GreaterThanOrEqualTo(-3).WithMessage("Floor -3den asagi ola bilmez");

        RuleFor(r => r.RoomPutDTO.ServiceId)
            .NotNull()
            .NotEmpty().WithMessage("ServiceId deyeri bos ve ya null deyer ala bilmez");
    }
}
