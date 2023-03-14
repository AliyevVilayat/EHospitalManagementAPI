using EHospital.Application.Features.Commands.Registration.DeleteRegistration;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Registration.UpdateRegistration;

public class UpdateRegistrationCommandHandler : IRequestHandler<UpdateRegistrationCommandRequest, UpdateRegistrationCommandResponse>
{
    private readonly IRegistrationService _registrationService;

    public UpdateRegistrationCommandHandler(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    public async Task<UpdateRegistrationCommandResponse> Handle(UpdateRegistrationCommandRequest request, CancellationToken cancellationToken)
    {
        await _registrationService.UpdateRegistrationAsync(request.RegistrationPutDTO);
        UpdateRegistrationCommandResponse response = new() { Message = "Registration successfully updated" };
        return response;
    }
}
