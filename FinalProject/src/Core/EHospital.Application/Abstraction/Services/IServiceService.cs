using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IServiceService
{
    Task<List<ServiceGetDTO>> GetAllServicesAsync();
    Task<List<ServiceGetDTO>> GetAllActiveServicesAsync();
    Task<List<ServiceGetDTO>> GetServiceByNameAsync(int page, int size, string name);
    Task<ServiceGetDTO> GetServiceByIdAsync(string id);

    Task CreateServiceAsync(ServicePostDTO servicePostDTO);
    Task UpdateServiceAsync(ServicePutDTO servicePutDTO);
    Task DeleteServiceAsync(string id);
    Task HardDeleteServiceAsync(string id);
}
