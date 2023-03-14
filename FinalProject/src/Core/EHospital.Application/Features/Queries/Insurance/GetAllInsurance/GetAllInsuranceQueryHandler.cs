using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Insurance.GetAllInsurance;

public class GetAllInsuranceQueryHandler : IRequestHandler<GetAllInsuranceQueryRequest, GetAllInsuranceQueryResponse>
{
    private readonly IInsuranceService _insuranceService;

    public GetAllInsuranceQueryHandler(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    public async Task<GetAllInsuranceQueryResponse> Handle(GetAllInsuranceQueryRequest request, CancellationToken cancellationToken)
    {
        List<InsuranceGetDTO> insuranceGetDTOs = await _insuranceService.GetAllInsuranceAsync();
        GetAllInsuranceQueryResponse response = new() { InsuranceGetDTOs = insuranceGetDTOs,InsurancesCount=insuranceGetDTOs.Count };
        return response;
    }
}
