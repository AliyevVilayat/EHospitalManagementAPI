using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Account.VerifyResetToken;

public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommandRequest, VerifyResetTokenCommandResponse>
{
    private readonly IAccountService _accountService;

    public VerifyResetTokenCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<VerifyResetTokenCommandResponse> Handle(VerifyResetTokenCommandRequest request, CancellationToken cancellationToken)
    {
        bool isVerified = await _accountService.VerifyResetToken(request.Id, request.ResetToken);
        string message = isVerified ? "The verify token operation has been successfully completed." : "The verify token operation hasn't been successfully completed.";
        VerifyResetTokenCommandResponse response = new() { IsVerified = isVerified,Message= message };
        return response;
    }
}
