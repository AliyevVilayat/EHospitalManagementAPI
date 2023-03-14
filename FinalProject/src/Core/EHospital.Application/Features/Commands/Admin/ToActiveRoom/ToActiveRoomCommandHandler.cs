using EHospital.Application.Features.Commands.Admin.ToActiveReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveRoom;

public class ToActiveRoomCommandHandler : IRequestHandler<ToActiveRoomCommandRequest, ToActiveRoomCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveRoomCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActiveRoomCommandResponse> Handle(ToActiveRoomCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveRoomAsync(request.Id);
        ToActiveRoomCommandResponse response = new() { Message = "Room successfully activated" };
        return response;
    }
}
