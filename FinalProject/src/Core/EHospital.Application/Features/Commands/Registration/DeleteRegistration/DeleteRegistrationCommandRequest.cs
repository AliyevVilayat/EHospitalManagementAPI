using MediatR;

namespace EHospital.Application.Features.Commands.Registration.DeleteRegistration;

public class DeleteRegistrationCommandRequest:IRequest<DeleteRegistrationCommandResponse>
{
    public string? IdStr { get; set; }
}
