using EHospital.Application.Features.Commands.Insurance.UpdateInsurance;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Insurance.DeleteInsurance;

public class DeleteInsuranceCommandHandler : IRequestHandler<DeleteInsuranceCommandRequest, DeleteInsuranceCommandResponse>
{
    private readonly IInsuranceService _insuranceService;

    public DeleteInsuranceCommandHandler(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    public async Task<DeleteInsuranceCommandResponse> Handle(DeleteInsuranceCommandRequest request, CancellationToken cancellationToken)
    {
        await _insuranceService.DeleteInsuranceAsync(request.Id);
        DeleteInsuranceCommandResponse response = new() { Message = "Insurance successfully deleted" };
        return response;
    }
}
