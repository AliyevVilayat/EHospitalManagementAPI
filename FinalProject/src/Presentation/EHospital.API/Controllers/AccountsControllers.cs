using EHospital.Application.DTOs;
using EHospital.Application.Features.Commands.Account.ForgotPassword;
using EHospital.Application.Features.Commands.Account.Login;
using EHospital.Application.Features.Commands.Account.ResetPassword;
using EHospital.Application.Features.Commands.Account.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[AllowAnonymous]
public class AccountsControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginCommandRequest loginUserCommandRequest)
    {
        LoginCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);       
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromQuery] ForgotPasswordCommandRequest forgotPasswordCommandRequest)
    {
        ForgotPasswordCommandResponse response = await _mediator.Send(forgotPasswordCommandRequest);
        return Ok(response);
    }

    [HttpPost("verify-reset-token")]
    public async Task<IActionResult> VerifyResetToken([FromQuery] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
    {
        VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
        return Ok(response);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommandRequest resetPasswordCommandRequest)
    {
        ResetPasswordCommandResponse response = await _mediator.Send(resetPasswordCommandRequest);
        return Ok(response);
    }
}

