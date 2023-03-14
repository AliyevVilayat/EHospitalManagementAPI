using MediatR;

namespace EHospital.Application.Features.Commands.Account.VerifyResetToken;

public class VerifyResetTokenCommandRequest:IRequest<VerifyResetTokenCommandResponse>
{
    public string? Id { get; set; }
    public string? ResetToken { get; set; }
}