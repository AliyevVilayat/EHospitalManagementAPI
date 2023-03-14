using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Account.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
{
    private readonly IAccountService _accountService;

    public ForgotPasswordCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<ForgotPasswordCommandResponse> Handle(ForgotPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        await _accountService.ForgotPassword(request.Email);
        ForgotPasswordCommandResponse response = new() { Message= "The e-mail has been sent successfully for the forgot password process." };
        return response;
    }
}
