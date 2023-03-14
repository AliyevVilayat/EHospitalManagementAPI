using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IDoctorService
{
    Task<List<DoctorGetDTO>> GetAllDoctorsAsync();
    Task<List<DoctorGetDTO>> GetAllActiveDoctorsAsync();
    Task<List<DoctorGetDTO>> GetDoctorByNameAsync(int page, int size, string name);
    Task<DoctorGetDTO> GetDoctorBySeriaNumberAsync(string seriaNumber);
    Task<DoctorGetDTO> GetDoctorByIdAsync(string id);

    Task CreateDoctorAsync(DoctorPostDTO doctorPostDTO);
    Task UpdateDoctorAsync(DoctorPutDTO doctorPutDTO);
    Task DeleteDoctorAsync(string id);
    Task HardDeleteDoctorAsync(string id);
}
