using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetAllRoom;

public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomQueryRequest, GetAllRoomQueryResponse>
{
    private readonly IRoomService _roomService;

    public GetAllRoomQueryHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<GetAllRoomQueryResponse> Handle(GetAllRoomQueryRequest request, CancellationToken cancellationToken)
    {
        List<RoomGetDTO> roomGetDTOs = await _roomService.GetAllRoomAsync();
        GetAllRoomQueryResponse response = new() { RoomGetDTOs = roomGetDTOs, RoomsCount = roomGetDTOs.Count };
        return response;
    }
}
