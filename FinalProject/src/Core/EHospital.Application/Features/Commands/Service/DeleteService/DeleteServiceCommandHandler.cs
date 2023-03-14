using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Service.DeleteInsurance;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommandRequest, DeleteServiceCommandResponse>
{
    private readonly IServiceService _serviceService;

    public DeleteServiceCommandHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<DeleteServiceCommandResponse> Handle(DeleteServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _serviceService.DeleteServiceAsync(request.Id);
        DeleteServiceCommandResponse response = new() { Message= "Service successfully deleted" };
        return response;
    }
}
