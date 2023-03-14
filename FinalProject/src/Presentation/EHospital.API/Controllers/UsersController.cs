using EHospital.Application.Features.Commands.User.CreateUser;
using EHospital.Application.Features.Commands.User.DeleteUser;
using EHospital.Application.Features.Queries.User.GetAllActiveUser;
using EHospital.Application.Features.Queries.User.GetAllUser;
using EHospital.Application.Features.Queries.User.GetByIdUser;
using EHospital.Application.Features.Queries.User.GetByUserNameUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Moderator,Admin")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllUserQueryRequest getAllUserQueryRequest)
    {
        GetAllUserQueryResponse response = await _mediator.Send(getAllUserQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveUserQueryRequest getAllActiveUserQueryRequest)
    {
        GetAllActiveUserQueryResponse response = await _mediator.Send(getAllActiveUserQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdUserQueryRequest getByIdUserQueryRequest)
    {
        GetByIdUserQueryResponse response = await _mediator.Send(getByIdUserQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("UserName")]
    public async Task<IActionResult> GetByUserName([FromQuery] GetByUserNameUserQueryRequest getByUserNameUserQueryRequest)
    {
        GetByUserNameUserQueryResponse response = await _mediator.Send(getByUserNameUserQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromForm] CreateUserCommandRequest createUserCommandRequest)
    {
        CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpDelete]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromQuery] DeleteUserCommandRequest deleteUserCommandRequest)
    {
        DeleteUserCommandResponse response = await _mediator.Send(deleteUserCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
