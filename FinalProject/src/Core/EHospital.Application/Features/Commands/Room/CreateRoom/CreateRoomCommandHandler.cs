using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Room.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommandRequest, CreateRoomCommandResponse>
{
    private readonly IRoomService _roomService;

    public CreateRoomCommandHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<CreateRoomCommandResponse> Handle(CreateRoomCommandRequest request, CancellationToken cancellationToken)
    {
        await _roomService.CreateRoomAsync(request.RoomPostDTO);
        CreateRoomCommandResponse response = new() { Message = "Room successfully created" };
        return response;
    }
}
