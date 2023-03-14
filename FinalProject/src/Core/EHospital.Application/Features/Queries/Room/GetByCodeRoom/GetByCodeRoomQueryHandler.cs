using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetByCodeRoom;

public class GetByCodeRoomQueryHandler : IRequestHandler<GetByCodeRoomQueryRequest, GetByCodeRoomQueryResponse>
{
    private readonly IRoomService _roomService;

    public GetByCodeRoomQueryHandler(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<GetByCodeRoomQueryResponse> Handle(GetByCodeRoomQueryRequest request, CancellationToken cancellationToken)
    {
        RoomGetDTO roomGetDTO= await _roomService.GetRoomByCodeAsync(request.Code);
        GetByCodeRoomQueryResponse response = new() { RoomGetDTO = roomGetDTO };
        return response;
    }
}
