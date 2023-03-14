using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IGenderService
{
    Task<List<GenderGetDTO>> GetAllGenderAsync();
    Task<GenderGetDTO> GetGenderByIdAsync(string id);
}
