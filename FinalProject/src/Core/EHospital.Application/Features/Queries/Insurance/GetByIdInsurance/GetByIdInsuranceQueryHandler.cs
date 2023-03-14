using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Insurance.GetByIdInsurance;

public class GetByIdInsuranceQueryHandler : IRequestHandler<GetByIdInsuranceQueryRequest, GetByIdInsuranceQueryResponse>
{
    private readonly IInsuranceService _insuranceService;

    public GetByIdInsuranceQueryHandler(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    public async Task<GetByIdInsuranceQueryResponse> Handle(GetByIdInsuranceQueryRequest request, CancellationToken cancellationToken)
    {
        InsuranceGetDTO insuranceGetDTO = await _insuranceService.GetInsuranceByIdAsync(request.Id);
        GetByIdInsuranceQueryResponse response = new() { InsuranceGetDTO = insuranceGetDTO };
        return response;
    }
}
