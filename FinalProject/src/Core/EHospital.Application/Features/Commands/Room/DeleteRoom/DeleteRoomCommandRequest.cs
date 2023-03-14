using EHospital.Application.Features.Commands.Room.CreateRoom;
using MediatR;

namespace EHospital.Application.Features.Commands.Room.DeleteRoom;

public class DeleteRoomCommandRequest:IRequest<DeleteRoomCommandResponse>
{
    public string? IdStr { get; set; }
}
