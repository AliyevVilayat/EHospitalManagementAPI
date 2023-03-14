using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetByIdRoom;

public class GetByIdRoomQueryHandler : IRequestHandler<GetByIdRoomQueryRequest, GetByIdRoomQueryResponse>
{
    private readonly IRoomService _roomService;

    public GetByIdRoomQueryHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<GetByIdRoomQueryResponse> Handle(GetByIdRoomQueryRequest request, CancellationToken cancellationToken)
    {
        RoomGetDTO roomGetDTO = await _roomService.GetRoomByIdAsync(request.IdStr);
        GetByIdRoomQueryResponse response = new() { RoomGetDTO = roomGetDTO };
        return response;
    }
}
