using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IBloodGroupService
{
    Task<List<BloodGroupGetDTO>> GetAllBloodGroupAsync();
    Task<BloodGroupGetDTO> GetBloodGroupByIdAsync(string id);
}
