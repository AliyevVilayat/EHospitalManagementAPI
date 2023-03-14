namespace EHospital.Application.Features.Commands.Account.VerifyResetToken;

public class VerifyResetTokenCommandResponse
{
    public bool IsVerified { get; set; }
    public string? Message { get; set; }
}