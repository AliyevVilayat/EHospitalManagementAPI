using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Room.GetAllEmptyRoom;

public class GetAllEmptyRoomQueryResponse
{
    public List<RoomGetDTO> RoomGetDTOs { get; set; }
    public long RoomsCount { get; set; }
}
