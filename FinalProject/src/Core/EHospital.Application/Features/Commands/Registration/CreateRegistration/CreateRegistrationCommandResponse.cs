using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Commands.Registration.CreateRegistration;

public class CreateRegistrationCommandResponse
{
    public CheckDTO CheckDTO { get; set; }
    public string? Message { get; set; }
}
