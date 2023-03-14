using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Room.UpdateRoom;

public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommandRequest, UpdateRoomCommandResponse>
{
    private readonly IRoomService _roomService;

    public UpdateRoomCommandHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }
    public async Task<UpdateRoomCommandResponse> Handle(UpdateRoomCommandRequest request, CancellationToken cancellationToken)
    {
        await _roomService.UpdateRoomAsync(request.RoomPutDTO);
        UpdateRoomCommandResponse response = new() { Message = "Room successfully updated" };
        return response;
    }
}
