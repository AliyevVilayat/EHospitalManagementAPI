using EHospital.Application.Features.Commands.Admin.ToActiveService;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveUser;

public class ToActiveUserCommandHandler : IRequestHandler<ToActiveUserCommandRequest, ToActiveUserCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveUserCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActiveUserCommandResponse> Handle(ToActiveUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveUserAsync(request.Id);
        ToActiveUserCommandResponse response = new() { Message = "User successfully activated" };
        return response;
    }
}
