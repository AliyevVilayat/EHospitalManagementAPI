using EHospital.Application.Features.Commands.Insurance.DeleteInsurance;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Insurance.CreateInsurance;

public class CreateInsuranceCommandHandler : IRequestHandler<CreateInsuranceCommandRequest, CreateInsuranceCommandResponse>
{
    private readonly IInsuranceService _insuranceService;

    public CreateInsuranceCommandHandler(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    public async Task<CreateInsuranceCommandResponse> Handle(CreateInsuranceCommandRequest request, CancellationToken cancellationToken)
    {
        await _insuranceService.CreateInsuranceAsync(request.InsurancePostDTO);
        CreateInsuranceCommandResponse response = new() { Message = "Insurance successfully created" };
        return response;
    }
}
