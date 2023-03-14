using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetAllActiveRoom;

public class GetAllActiveRoomQueryHandler : IRequestHandler<GetAllActiveRoomQueryRequest, GetAllActiveRoomQueryResponse>
{
    private readonly IRoomService _roomService;

    public GetAllActiveRoomQueryHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }
    public async Task<GetAllActiveRoomQueryResponse> Handle(GetAllActiveRoomQueryRequest request, CancellationToken cancellationToken)
    {
        List<RoomGetDTO> roomGetDTOs = await _roomService.GetAllActiveRoomAsync();
        GetAllActiveRoomQueryResponse response = new() { RoomGetDTOs = roomGetDTOs,RoomsCount=roomGetDTOs.Count };
        return response;
    }
}
