using EHospital.Application.Features.Commands.Mail.SendMail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Moderator,Admin")]
public class MailsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MailsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendMail([FromForm] SendMailCommandRequest sendMailCommandRequest)
    {
        SendMailCommandResponse response = await _mediator.Send(sendMailCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }
}
