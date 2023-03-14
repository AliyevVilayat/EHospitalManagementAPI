using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IPatientService
{
    Task<List<PatientGetDTO>> GetAllPatientsAsync();
    Task<List<PatientGetDTO>> GetAllActivePatientsAsync();
    Task<List<PatientGetDTO>> GetPatientByNameAsync(int page,int size,string name);
    Task<PatientGetDTO> GetPatientBySeriaNumberAsync(string seriaNumber);
    Task<PatientGetDTO> GetPatientByIdAsync(string id);

    Task CreatePatientAsync(PatientPostDTO patientPostDTO);
    Task UpdatePatientAsync(PatientPutDTO patientPutDTO);
    Task DeletePatientAsync(string id);
    Task HardDeletePatientAsync(string id);
}
