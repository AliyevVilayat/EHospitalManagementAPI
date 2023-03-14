using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Service.UpdateInsurance;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest, UpdateServiceCommandResponse>
{
    private readonly IServiceService _serviceService;

    public UpdateServiceCommandHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<UpdateServiceCommandResponse> Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _serviceService.UpdateServiceAsync(request.ServicePutDTO);
        UpdateServiceCommandResponse response = new() { Message = "Service successfully updated" };
        return response;
    }
}
