using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Queries.Insurance.GetAllInsurance;

public class GetAllInsuranceQueryResponse
{
    public List<InsuranceGetDTO> InsuranceGetDTOs { get; set; }
    public long InsurancesCount { get; set; }
}

