using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Room.DeleteRoom;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommandRequest, DeleteRoomCommandResponse>
{
    private readonly IRoomService _roomService;

    public DeleteRoomCommandHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<DeleteRoomCommandResponse> Handle(DeleteRoomCommandRequest request, CancellationToken cancellationToken)
    {
        await _roomService.DeleteRoomAsync(request.IdStr);
        DeleteRoomCommandResponse response = new() { Message = "Room successfully deleted" };
        return response;
    }
}
