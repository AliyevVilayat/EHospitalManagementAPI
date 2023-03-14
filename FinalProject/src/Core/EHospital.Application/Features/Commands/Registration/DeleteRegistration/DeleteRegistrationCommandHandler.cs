using EHospital.Application.Features.Commands.Registration.CreateRegistration;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Registration.DeleteRegistration;

public class DeleteRegistrationCommandHandler : IRequestHandler<DeleteRegistrationCommandRequest, DeleteRegistrationCommandResponse>
{
    private readonly IRegistrationService _registrationService;

    public DeleteRegistrationCommandHandler(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    public async Task<DeleteRegistrationCommandResponse> Handle(DeleteRegistrationCommandRequest request, CancellationToken cancellationToken)
    {
        await _registrationService.DeleteRegistrationAsync(request.IdStr);
        DeleteRegistrationCommandResponse response = new() { Message = "Registration successfully deleted" };
        return response;
    }
}
