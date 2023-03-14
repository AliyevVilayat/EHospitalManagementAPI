using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Room.UpdateRoom;

public class UpdateRoomCommandRequest:IRequest<UpdateRoomCommandResponse>
{
    public RoomPutDTO RoomPutDTO { get; set; }
}
