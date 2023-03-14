using EHospital.Application.Features.Commands.Receptionist.CreateReceptionist;
using EHospital.Application.Features.Commands.Receptionist.DeleteReceptionist;
using EHospital.Application.Features.Commands.Receptionist.UpdateReceptionist;
using EHospital.Application.Features.Queries.Receptionist.GetAllActiveReceptionist;
using EHospital.Application.Features.Queries.Receptionist.GetAllReceptionist;
using EHospital.Application.Features.Queries.Receptionist.GetByIdReceptionist;
using EHospital.Application.Features.Queries.Receptionist.GetByNameReceptionist;
using EHospital.Application.Features.Queries.Receptionist.GetBySeriaNumberReceptionist;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Moderator,Admin")]
public class ReceptionistsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceptionistsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery] GetAllReceptionistQueryRequest getAllReceptionistQueryRequest)
    {
        GetAllReceptionistQueryResponse response = await _mediator.Send(getAllReceptionistQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveReceptionistQueryRequest getAllActiveReceptionistQueryRequest)
    {
        GetAllActiveReceptionistQueryResponse response = await _mediator.Send(getAllActiveReceptionistQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdReceptionistQueryRequest getByIdReceptionistQueryRequest)
    {
        GetByIdReceptionistQueryResponse response = await _mediator.Send(getByIdReceptionistQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameReceptionistQueryRequest getByNameReceptionistQueryRequest)
    {
        GetByNameReceptionistQueryResponse response = await _mediator.Send(getByNameReceptionistQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("SeriaNumber")]
    public async Task<IActionResult> GetBySeriaNumber([FromQuery] GetBySeriaNumberReceptionistQueryRequest getBySeriaNumberReceptionistQueryRequest)
    {
        GetBySeriaNumberReceptionistQueryResponse response = await _mediator.Send(getBySeriaNumberReceptionistQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Post([FromForm] CreateReceptionistCommandRequest createReceptionistCommandRequest)
    {
        CreateReceptionistCommandResponse response = await _mediator.Send(createReceptionistCommandRequest);
        return StatusCode((int)HttpStatusCode.Created,response);
    }

    [HttpPut("")]
    public async Task<IActionResult> Put([FromForm] UpdateReceptionistCommandRequest updateReceptionistCommandRequest)
    {
        UpdateReceptionistCommandResponse response = await _mediator.Send(updateReceptionistCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete("")]
    public async Task<IActionResult> Delete([FromForm] DeleteReceptionistCommandRequest deleteReceptionistCommandRequest)
    {
        DeleteReceptionistCommandResponse response = await _mediator.Send(deleteReceptionistCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
