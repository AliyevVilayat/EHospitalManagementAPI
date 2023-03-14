using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Room.CreateRoom;

public class CreateRoomCommandRequest:IRequest<CreateRoomCommandResponse>
{
    public RoomPostDTO RoomPostDTO { get; set; }
}
