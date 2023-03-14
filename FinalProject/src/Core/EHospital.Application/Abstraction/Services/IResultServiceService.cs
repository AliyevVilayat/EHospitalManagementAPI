using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IResultServiceService
{
    Task<List<ResultServiceGetDTO>> GetAllResultServiceAsync();
    Task<List<ResultServiceGetDTO>> GetAllActiveResultServiceAsync();
    Task<ResultServiceGetDTO> GetResultServiceByIdAsync(string id);

    Task CreateResultServiceAsync(ResultServicePostDTO resultServicePostDTO);
    Task UpdateResultServiceAsync(ResultServicePutDTO resultServicePutDTO);
    Task DeleteResultServiceAsync(string id);
    Task HardDeleteResultServiceAsync(string id);
    
}
