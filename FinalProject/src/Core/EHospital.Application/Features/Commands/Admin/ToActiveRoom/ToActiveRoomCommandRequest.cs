using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveRoom;

public class ToActiveRoomCommandRequest:IRequest<ToActiveRoomCommandResponse>
{
    public string? Id { get; set; }
}