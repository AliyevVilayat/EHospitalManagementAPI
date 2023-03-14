using EHospital.Application.Features.Commands.Field.CreateField;
using EHospital.Application.Features.Commands.Field.DeleteField;
using EHospital.Application.Features.Commands.Field.UpdateField;
using EHospital.Application.Features.Queries.Field.GetAllActiveField;
using EHospital.Application.Features.Queries.Field.GetAllField;
using EHospital.Application.Features.Queries.Field.GetByIdField;
using EHospital.Application.Features.Queries.Field.GetByNameField;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Receptionist,Moderator,Admin")]
public class FieldsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FieldsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllFieldQueryRequest getAllFieldQueryRequest)
    {
        GetAllFieldQueryResponse response = await _mediator.Send(getAllFieldQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveFieldQueryRequest getAllActiveFieldQueryRequest)
    {
        GetAllActiveFieldQueryResponse response = await _mediator.Send(getAllActiveFieldQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdFieldQueryRequest getByIdFieldQueryRequest)
    {
        GetByIdFieldQueryResponse response = await _mediator.Send(getByIdFieldQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameFieldQueryRequest getByNameFieldQueryRequest)
    {
        GetByNameFieldQueryResponse response = await _mediator.Send(getByNameFieldQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Post([FromForm] CreateFieldCommandRequest createFieldCommandRequest)
    {
        CreateFieldCommandResponse response = await _mediator.Send(createFieldCommandRequest);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Put([FromForm] UpdateFieldCommandRequest updateFieldCommandRequest)
    {
        UpdateFieldCommandResponse response = await _mediator.Send(updateFieldCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteFieldCommandRequest deleteFieldCommandRequest)
    {
        DeleteFieldCommandResponse response = await _mediator.Send(deleteFieldCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }
}
