using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IReceptionistService
{
    Task<List<ReceptionistGetDTO>> GetAllReceptionistsAsync();
    Task<List<ReceptionistGetDTO>> GetAllActiveReceptionistsAsync();
    Task<List<ReceptionistGetDTO>> GetReceptionistByNameAsync(int page, int size, string name);
    Task<ReceptionistGetDTO> GetReceptionistBySeriaNumberAsync(string seriaNumber);
    Task<ReceptionistGetDTO> GetReceptionistByIdAsync(string id);

    Task CreateReceptionistAsync(ReceptionistPostDTO receptionistPostDTO);
    Task UpdateReceptionistAsync(ReceptionistPutDTO receptionistPutDTO);
    Task DeleteReceptionistAsync(string id);
    Task HardDeleteReceptionistAsync(string id);
}
