using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Room.GetAllRoom;

public class GetAllRoomQueryResponse
{
    public List<RoomGetDTO> RoomGetDTOs { get; set; }
    public long RoomsCount { get; set; }
}
