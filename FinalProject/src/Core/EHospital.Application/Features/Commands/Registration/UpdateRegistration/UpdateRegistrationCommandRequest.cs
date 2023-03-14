using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Registration.UpdateRegistration;

public class UpdateRegistrationCommandRequest:IRequest<UpdateRegistrationCommandResponse>
{
    public RegistrationPutDTO RegistrationPutDTO { get; set; }
}
