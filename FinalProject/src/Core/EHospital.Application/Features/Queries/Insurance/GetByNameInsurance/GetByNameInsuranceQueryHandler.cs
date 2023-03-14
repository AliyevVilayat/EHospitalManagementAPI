using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Insurance.GetByNameInsurance;

public class GetByNameInsuranceQueryHandler : IRequestHandler<GetByNameInsuranceQueryRequest, GetByNameInsuranceQueryResponse>
{
    private readonly IInsuranceService _insuranceService;

    public GetByNameInsuranceQueryHandler(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    public async Task<GetByNameInsuranceQueryResponse> Handle(GetByNameInsuranceQueryRequest request, CancellationToken cancellationToken)
    {
        List<InsuranceGetDTO> insuranceGetDTOs = await _insuranceService.GetInsuranceByNameAsync(request.Page, request.Size, request.Name);
        GetByNameInsuranceQueryResponse response = new() { InsuranceGetDTOs = insuranceGetDTOs, InsurancesCount = insuranceGetDTOs.Count };
        return response;
    }
}
