using MediatR;

namespace EHospital.Application.Features.Commands.Account.ForgotPassword;

public class ForgotPasswordCommandRequest:IRequest<ForgotPasswordCommandResponse>
{
    public string? Email { get; set; }
}