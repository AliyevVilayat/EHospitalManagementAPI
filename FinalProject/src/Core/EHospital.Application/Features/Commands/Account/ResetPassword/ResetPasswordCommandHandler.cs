using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Account.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
{
    private readonly IAccountService _accountService;

    public ResetPasswordCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        await _accountService.ResetPassword(request.ResetPasswordDTO);
        string message = "The reset password operation has been carried out successfully.";
        ResetPasswordCommandResponse response = new() { Message= message };
        return response;
    }
}
