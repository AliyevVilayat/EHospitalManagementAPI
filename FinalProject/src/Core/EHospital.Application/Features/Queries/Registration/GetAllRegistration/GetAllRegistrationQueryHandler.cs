using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Registration.GetAllRegistration;

public class GetAllRegistrationQueryHandler : IRequestHandler<GetAllRegistrationQueryRequest, GetAllRegistrationQueryResponse>
{
    private readonly IRegistrationService _registrationService;

    public GetAllRegistrationQueryHandler(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    public async Task<GetAllRegistrationQueryResponse> Handle(GetAllRegistrationQueryRequest request, CancellationToken cancellationToken)
    {
        List<RegistrationGetDTO> registrationGetDTOs = await _registrationService.GetAllRegistrationAsync();
        GetAllRegistrationQueryResponse response = new() { RegistrationGetDTOs = registrationGetDTOs, RegistrationsCount = registrationGetDTOs.Count };
        return response;
    }
}
