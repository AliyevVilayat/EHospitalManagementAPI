using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveService;

public class ToActiveServiceCommandHandler : IRequestHandler<ToActiveServiceCommandRequest, ToActiveServiceCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveServiceCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActiveServiceCommandResponse> Handle(ToActiveServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveServiceAsync(request.Id);
        ToActiveServiceCommandResponse response = new() { Message = "Service successfully activated" };
        return response;
    }
}
