using EHospital.Application.Features.Commands.ResultService.CreateResultService;
using EHospital.Application.Features.Commands.ResultService.DeleteResultService;
using EHospital.Application.Features.Commands.ResultService.UpdateResultService;
using EHospital.Application.Features.Queries.ResultService.GetAllActiveResultService;
using EHospital.Application.Features.Queries.ResultService.GetAllResultService;
using EHospital.Application.Features.Queries.ResultService.GetByIdResultService;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Doctor,Moderator,Admin")]
public class ResultServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResultServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllResultServiceQueryRequest getAllResultServiceQueryRequest)
    {
        GetAllResultServiceQueryResponse response = await _mediator.Send(getAllResultServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveResultServiceQueryRequest getAllActiveResultServiceQueryRequest)
    {
        GetAllActiveResultServiceQueryResponse response = await _mediator.Send(getAllActiveResultServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdResultServiceQueryRequest getByIdResultServiceQueryRequest)
    {
        GetByIdResultServiceQueryResponse response = await _mediator.Send(getByIdResultServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Post([FromForm] CreateResultServiceCommandRequest createResultServiceCommandRequest)
    {
        CreateResultServiceCommandResponse response = await _mediator.Send(createResultServiceCommandRequest);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Put([FromForm] UpdateResultServiceCommandRequest updateResultServiceCommandRequest)
    {
        UpdateResultServiceCommandResponse response = await _mediator.Send(updateResultServiceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }

    [HttpDelete("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteResultServiceCommandRequest deleteResultServiceCommandRequest)
    {
        DeleteResultServiceCommandResponse response =  await _mediator.Send(deleteResultServiceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }
}
