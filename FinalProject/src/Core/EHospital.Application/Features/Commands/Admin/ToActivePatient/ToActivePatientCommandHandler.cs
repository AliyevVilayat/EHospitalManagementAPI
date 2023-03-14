using EHospital.Application.Features.Commands.Admin.ToActiveInsurance;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActivePatient;

public class ToActivePatientCommandHandler : IRequestHandler<ToActivePatientCommandRequest, ToActivePatientCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActivePatientCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActivePatientCommandResponse> Handle(ToActivePatientCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActivePatientAsync(request.Id);
        ToActivePatientCommandResponse response = new() { Message = "Patient successfully activated" };
        return response;
    }
}
