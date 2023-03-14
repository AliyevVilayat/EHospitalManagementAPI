using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Account.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly IAccountService _authService;

    public LoginCommandHandler(IAccountService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        TokenResponseDTO tokenResponseDTO = await _authService.LoginAsync(request.LoginDTO);
        LoginCommandResponse response = new() { TokenResponse = tokenResponseDTO,Message= "The login process has been done successfully." };
        return response;
    }
}
