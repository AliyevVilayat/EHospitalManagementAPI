using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Registration.GetAllRegistration;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Registration.GetAllActiveRegistration;

public class GetAllActiveRegistrationQueryHandler : IRequestHandler<GetAllActiveRegistrationQueryRequest, GetAllActiveRegistrationQueryResponse>
{
    private readonly IRegistrationService _registrationService;

    public GetAllActiveRegistrationQueryHandler(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    public async Task<GetAllActiveRegistrationQueryResponse> Handle(GetAllActiveRegistrationQueryRequest request, CancellationToken cancellationToken)
    {
        List<RegistrationGetDTO> registrationGetDTOs = await _registrationService.GetAllActiveRegistrationAsync();
        GetAllActiveRegistrationQueryResponse response = new() { RegistrationGetDTOs = registrationGetDTOs,RegistrationsCount=registrationGetDTOs.Count };
        return response;
    }
}
