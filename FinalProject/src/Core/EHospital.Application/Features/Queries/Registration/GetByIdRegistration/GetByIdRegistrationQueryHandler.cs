using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Registration.GetByIdRegistration;

public class GetByIdRegistrationQueryHandler : IRequestHandler<GetByIdRegistrationQueryRequest, GetByIdRegistrationQueryResponse>
{
    private readonly IRegistrationService _registrationService;

    public GetByIdRegistrationQueryHandler(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    public async Task<GetByIdRegistrationQueryResponse> Handle(GetByIdRegistrationQueryRequest request, CancellationToken cancellationToken)
    {
        RegistrationGetDTO registrationGetDTO= await _registrationService.GetRegistrationByIdAsync(request.IdStr);
        GetByIdRegistrationQueryResponse response = new() { RegistrationGetDTO = registrationGetDTO };
        return response;
    }
}
