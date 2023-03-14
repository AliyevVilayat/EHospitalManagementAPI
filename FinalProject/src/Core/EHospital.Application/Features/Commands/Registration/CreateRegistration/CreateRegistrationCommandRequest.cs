using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Registration.CreateRegistration;

public class CreateRegistrationCommandRequest:IRequest<CreateRegistrationCommandResponse>
{
    public RegistrationPostDTO RegistrationPostDTO { get; set; }
}
