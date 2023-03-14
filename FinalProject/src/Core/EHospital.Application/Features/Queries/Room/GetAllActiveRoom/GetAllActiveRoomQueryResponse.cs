using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Room.GetAllActiveRoom;

public class GetAllActiveRoomQueryResponse
{
    public List<RoomGetDTO> RoomGetDTOs { get; set; }
    public long RoomsCount { get; set; }
}
