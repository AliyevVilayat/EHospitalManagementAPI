using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Commands.Account.Login;

public class LoginCommandResponse
{
    public TokenResponseDTO TokenResponse { get; set; }
    public string? Message { get; set; }
}
