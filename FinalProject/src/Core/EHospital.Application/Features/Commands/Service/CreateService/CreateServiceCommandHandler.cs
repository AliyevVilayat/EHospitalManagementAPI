using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Service.CreateInsurance;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommandRequest, CreateServiceCommandResponse>
{
    private readonly IServiceService _serviceService;

    public CreateServiceCommandHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<CreateServiceCommandResponse> Handle(CreateServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _serviceService.CreateServiceAsync(request.ServicePostDTO);
        CreateServiceCommandResponse response = new() { Message = "Service successfully created" };
        return response;
    }
}
