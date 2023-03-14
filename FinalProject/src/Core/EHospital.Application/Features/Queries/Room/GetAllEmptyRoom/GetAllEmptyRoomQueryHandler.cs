using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetAllEmptyRoom;

public class GetAllEmptyRoomQueryHandler:IRequestHandler<GetAllEmptyRoomQueryRequest, GetAllEmptyRoomQueryResponse>
{
    private readonly IRoomService _roomService;

    public GetAllEmptyRoomQueryHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<GetAllEmptyRoomQueryResponse> Handle(GetAllEmptyRoomQueryRequest request, CancellationToken cancellationToken)
    {
        List<RoomGetDTO> roomGetDTOs = await _roomService.GetAllEmptyRoomAsync();
        GetAllEmptyRoomQueryResponse response = new() { RoomGetDTOs = roomGetDTOs, RoomsCount = roomGetDTOs.Count };
        return response;
    }
}
