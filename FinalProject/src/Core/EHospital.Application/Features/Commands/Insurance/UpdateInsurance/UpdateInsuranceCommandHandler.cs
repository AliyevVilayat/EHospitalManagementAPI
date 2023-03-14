using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Insurance.UpdateInsurance;

public class UpdateInsuranceCommandHandler : IRequestHandler<UpdateInsuranceCommandRequest, UpdateInsuranceCommandResponse>
{
    private readonly IInsuranceService _insuranceService;

    public UpdateInsuranceCommandHandler(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    public async Task<UpdateInsuranceCommandResponse> Handle(UpdateInsuranceCommandRequest request, CancellationToken cancellationToken)
    {
        await _insuranceService.UpdateInsuranceAsync(request.InsurancePutDTO);
        UpdateInsuranceCommandResponse response = new() { Message = "Insurance successfully updated" };
        return response;
    }
}
