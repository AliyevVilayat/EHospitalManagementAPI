using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Insurance.GetByNameInsurance;

public class GetByNameInsuranceQueryResponse
{
    public List<InsuranceGetDTO> InsuranceGetDTOs { get; set; }
    public long InsurancesCount { get; set; }
}
