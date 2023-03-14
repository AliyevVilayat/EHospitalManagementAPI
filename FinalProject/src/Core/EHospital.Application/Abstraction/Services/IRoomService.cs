using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IRoomService
{
    Task<List<RoomGetDTO>> GetAllRoomAsync();
    Task<List<RoomGetDTO>> GetAllActiveRoomAsync();
    Task<List<RoomGetDTO>> GetAllEmptyRoomAsync();
    Task<RoomGetDTO> GetRoomByCodeAsync(string code);
    Task<RoomGetDTO> GetRoomByIdAsync(string id);

    Task CreateRoomAsync(RoomPostDTO roomPostDTO);
    Task UpdateRoomAsync(RoomPutDTO roomPutDTO);
    Task DeleteRoomAsync(string id);
    Task HardDeleteRoomAsync(string id);
}
