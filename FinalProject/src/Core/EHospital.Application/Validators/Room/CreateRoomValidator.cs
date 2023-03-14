using EHospital.Application.Features.Commands.Room.CreateRoom;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateRoomValidator:AbstractValidator<CreateRoomCommandRequest>
{
    public CreateRoomValidator()
    {
        RuleFor(r => r.RoomPostDTO.RoomCode)
            .NotNull()
            .NotEmpty().WithMessage("RoomCode deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(10).WithMessage("RoomCode deyeri 10 simvoldan artiq ola bilmez");

        RuleFor(r => r.RoomPostDTO.Floor)
            .NotNull()
            .NotEmpty().WithMessage("Floor deyeri bos ve ya null deyer ala bilmez")
            .GreaterThanOrEqualTo(-3).WithMessage("Floor -3den asagi ola bilmez");

        RuleFor(r => r.RoomPostDTO.ServiceId)
            .NotNull()
            .NotEmpty().WithMessage("ServiceId deyeri bos ve ya null deyer ala bilmez");
    }
}
