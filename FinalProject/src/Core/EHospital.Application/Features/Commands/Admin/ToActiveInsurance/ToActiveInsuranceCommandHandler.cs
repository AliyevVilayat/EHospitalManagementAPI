using EHospital.Application.Features.Commands.Admin.ToActiveField;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveInsurance;

public class ToActiveInsuranceCommandHandler : IRequestHandler<ToActiveInsuranceCommandRequest, ToActiveInsuranceCommandResponse>
{
    private readonly IAdminService _adminService;

    public ToActiveInsuranceCommandHandler(IAdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<ToActiveInsuranceCommandResponse> Handle(ToActiveInsuranceCommandRequest request, CancellationToken cancellationToken)
    {
        await _adminService.ToActiveInsuranceAsync(request.Id);
        ToActiveInsuranceCommandResponse response = new() { Message = "Insurance successfully activated" };
        return response;
    }
}
