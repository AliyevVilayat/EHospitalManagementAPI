using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveDoctor;

public class ToActiveDoctorCommandHandler : IRequestHandler<ToActiveDoctorCommandRequest, ToActiveDoctorCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveDoctorCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<ToActiveDoctorCommandResponse> Handle(ToActiveDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveDoctorAsync(request.Id);
        ToActiveDoctorCommandResponse response = new() { Message= "Doctor successfully activated"};
        return response;
    }
}
