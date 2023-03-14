using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Registration.GetByDoctorIdRegistration;

public class GetByDoctorIdRegistrationHandler : IRequestHandler<GetByDoctorIdRegistrationRequest, GetByDoctorIdRegistrationResponse>
{
    private readonly IRegistrationService _registrationService;

    public GetByDoctorIdRegistrationHandler(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    public async Task<GetByDoctorIdRegistrationResponse> Handle(GetByDoctorIdRegistrationRequest request, CancellationToken cancellationToken)
    {
        List<RegistrationGetDTO> registrationGetDTOs = await _registrationService.GetRegistrationByDoctorIdAsync(request.IdStr);
        GetByDoctorIdRegistrationResponse response = new() {RegistrationGetDTOs= registrationGetDTOs, RegistrationsCount = registrationGetDTOs.Count };
        return response;
    }
}
