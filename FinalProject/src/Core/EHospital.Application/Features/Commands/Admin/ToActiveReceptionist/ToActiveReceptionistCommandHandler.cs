using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveReceptionist;

public class ToActiveReceptionistCommandHandler : IRequestHandler<ToActiveReceptionistCommandRequest, ToActiveReceptionistCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveReceptionistCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActiveReceptionistCommandResponse> Handle(ToActiveReceptionistCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveReceptionistAsync(request.Id);
        ToActiveReceptionistCommandResponse response = new() { Message = "Receptionist successfully activated" };
        return response;
    }
}
