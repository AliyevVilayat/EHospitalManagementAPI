using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IInsuranceService
{
    Task<List<InsuranceGetDTO>> GetAllInsuranceAsync();
    Task<InsuranceGetDTO> GetInsuranceByIdAsync(string id);
    Task<List<InsuranceGetDTO>> GetInsuranceByNameAsync(int page, int size,string name);

    Task CreateInsuranceAsync(InsurancePostDTO insurancePostDTO);
    Task UpdateInsuranceAsync(InsurancePutDTO insurancePutDTO);
    Task DeleteInsuranceAsync(string id);
    Task HardDeleteInsuranceAsync(string id);
}
