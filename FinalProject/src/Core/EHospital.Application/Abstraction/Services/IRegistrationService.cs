using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IRegistrationService
{
    Task<List<RegistrationGetDTO>> GetAllRegistrationAsync();
    Task<List<RegistrationGetDTO>> GetAllActiveRegistrationAsync();
    Task<List<RegistrationGetDTO>> GetRegistrationByDoctorIdAsync(string id);
    Task<RegistrationGetDTO> GetRegistrationByIdAsync(string id);

    Task CreateRegistrationAsync(RegistrationPostDTO registrationPostDTO);
    Task UpdateRegistrationAsync(RegistrationPutDTO registrationPutDTO);
    Task DeleteRegistrationAsync(string id);
    Task HardDeleteRegistrationAsync(string id);
}
