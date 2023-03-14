using EHospital.Application.Features.Commands.Service.CreateInsurance;
using EHospital.Application.Features.Commands.Service.DeleteInsurance;
using EHospital.Application.Features.Commands.Service.UpdateInsurance;
using EHospital.Application.Features.Queries.Service.GetAllActiveService;
using EHospital.Application.Features.Queries.Service.GetAllService;
using EHospital.Application.Features.Queries.Service.GetByIdService;
using EHospital.Application.Features.Queries.Service.GetByNameService;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Receptionist,Moderator,Admin")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery] GetAllServiceQueryRequest getAllServiceQueryRequest)
    {
        GetAllServiceQueryResponse response = await _mediator.Send(getAllServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveServiceQueryRequest getAllActiveServiceQueryRequest)
    {
        GetAllActiveServiceQueryResponse response = await _mediator.Send(getAllActiveServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdServiceQueryRequest getByIdServiceQueryRequest)
    {
        GetByIdServiceQueryResponse response = await _mediator.Send(getByIdServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameServiceQueryRequest getByNameServiceQueryRequest)
    {
        GetByNameServiceQueryResponse response = await _mediator.Send(getByNameServiceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Post([FromForm] CreateServiceCommandRequest createInsuranceCommandRequest)
    {

        CreateServiceCommandResponse response = await _mediator.Send(createInsuranceCommandRequest);

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Put([FromForm] UpdateServiceCommandRequest updateServiceCommandRequest)
    {
        UpdateServiceCommandResponse response = await _mediator.Send(updateServiceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }

    [HttpDelete]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteServiceCommandRequest deleteInsuranceCommandRequest)
    {
        DeleteServiceCommandResponse response = await _mediator.Send(deleteInsuranceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK);
    }
}
