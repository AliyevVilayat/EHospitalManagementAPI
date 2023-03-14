using EHospital.Application.Features.Commands.Role.CreateRole;
using EHospital.Application.Features.Commands.Role.DeleteRole;
using EHospital.Application.Features.Commands.Role.UpdateRole;
using EHospital.Application.Features.Queries.Role.GetAllRole;
using EHospital.Application.Features.Queries.Role.GetByIdRole;
using EHospital.Application.Features.Queries.Role.GetByNameRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Moderator,Admin")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]    
    public async Task<IActionResult> Get([FromQuery] GetAllRoleQueryRequest getAllRoleQueryRequest)
    {
        GetAllRoleQueryResponse response = await _mediator.Send(getAllRoleQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]  
    public async Task<IActionResult> GetById([FromQuery] GetByIdRoleQueryRequest getByIdRoleQueryRequest)
    {
        GetByIdRoleQueryResponse response = await _mediator.Send(getByIdRoleQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]   
    public async Task<IActionResult> GetByName([FromQuery] GetByNameRoleQueryRequest getByNameRoleQueryRequest)
    {
        GetByNameRoleQueryResponse response = await _mediator.Send(getByNameRoleQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost]   
    public async Task<IActionResult> Post([FromForm] CreateRoleCommandRequest createRoleCommandRequest)
    {
        CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut]    
    public async Task<IActionResult> Put([FromForm] UpdateRoleCommandRequest updateRoleCommandRequest)
    {
        UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
        return StatusCode((int)HttpStatusCode.Created,response);
    }

    [HttpDelete]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromQuery] DeleteRoleCommandRequest deleteRoleCommandRequest)
    {
        DeleteRoleCommandResponse response = await _mediator.Send(deleteRoleCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
