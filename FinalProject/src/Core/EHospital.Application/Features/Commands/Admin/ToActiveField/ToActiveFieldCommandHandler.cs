using EHospital.Application.Features.Commands.Admin.ToActiveDoctor;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveField;

public class ToActiveFieldCommandHandler : IRequestHandler<ToActiveFieldCommandRequest, ToActiveFieldCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveFieldCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActiveFieldCommandResponse> Handle(ToActiveFieldCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveFieldAsync(request.Id);
        ToActiveFieldCommandResponse response = new() { Message = "Field successfully activated" };
        return response;
    }
}
