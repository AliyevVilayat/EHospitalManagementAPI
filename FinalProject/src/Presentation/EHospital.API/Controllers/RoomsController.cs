using EHospital.Application.Features.Commands.Room.CreateRoom;
using EHospital.Application.Features.Commands.Room.DeleteRoom;
using EHospital.Application.Features.Commands.Room.UpdateRoom;
using EHospital.Application.Features.Queries.Room.GetAllActiveRoom;
using EHospital.Application.Features.Queries.Room.GetAllEmptyRoom;
using EHospital.Application.Features.Queries.Room.GetAllRoom;
using EHospital.Application.Features.Queries.Room.GetByCodeRoom;
using EHospital.Application.Features.Queries.Room.GetByIdRoom;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles ="Receptionist,Moderator,Admin")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllRoomQueryRequest getAllRoomQueryRequest)
    {
        GetAllRoomQueryResponse response = await _mediator.Send(getAllRoomQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveRoomQueryRequest getAllActiveRoomQueryRequest)
    {
        GetAllActiveRoomQueryResponse response = await _mediator.Send(getAllActiveRoomQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Empty")]
    public async Task<IActionResult> GetAllEmpty([FromQuery] GetAllEmptyRoomQueryRequest getAllEmptyRoomQueryRequest)
    {
        GetAllEmptyRoomQueryResponse response = await _mediator.Send(getAllEmptyRoomQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdRoomQueryRequest getByIdRoomQueryRequest)
    {
        GetByIdRoomQueryResponse response = await _mediator.Send(getByIdRoomQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Code")]
    public async Task<IActionResult> GetByCode([FromQuery] GetByCodeRoomQueryRequest getByCodeRoomQueryRequest)
    {
        GetByCodeRoomQueryResponse response = await _mediator.Send(getByCodeRoomQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Post([FromForm] CreateRoomCommandRequest createRoomCommandRequest)
    {
        CreateRoomCommandResponse response = await _mediator.Send(createRoomCommandRequest);
        return StatusCode((int)HttpStatusCode.Created,response);
    }

    [HttpPut("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Put([FromForm] UpdateRoomCommandRequest updateRoomCommandRequest)
    {
        UpdateRoomCommandResponse response = await _mediator.Send(updateRoomCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete("")]
    //[Authorize(Roles ="Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteRoomCommandRequest deleteRoomCommandRequest)
    {
        DeleteRoomCommandResponse response = await _mediator.Send(deleteRoomCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
