using EHospital.Application.Features.Commands.Registration.CreateRegistration;
using EHospital.Application.Features.Commands.Registration.DeleteRegistration;
using EHospital.Application.Features.Commands.Registration.UpdateRegistration;
using EHospital.Application.Features.Queries.Registration.GetAllActiveRegistration;
using EHospital.Application.Features.Queries.Registration.GetAllRegistration;
using EHospital.Application.Features.Queries.Registration.GetByDoctorIdRegistration;
using EHospital.Application.Features.Queries.Registration.GetByIdRegistration;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Receptionist,Moderator,Admin")]
public class RegistrationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllRegistrationQueryRequest getAllRegistrationQueryRequest)
    {
        GetAllRegistrationQueryResponse response = await _mediator.Send(getAllRegistrationQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]

    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveRegistrationQueryRequest getAllActiveRegistrationQueryRequest)
    {
        GetAllActiveRegistrationQueryResponse response = await _mediator.Send(getAllActiveRegistrationQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("DoctorId")]
    //[Authorize(Roles = "Doctor,Receptionist,Moderator,Admin")]
    public async Task<IActionResult> GetByDoctorId([FromQuery] GetByDoctorIdRegistrationRequest getByDoctorIdRegistrationRequest)
    {
        GetByDoctorIdRegistrationResponse response = await _mediator.Send(getByDoctorIdRegistrationRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdRegistrationQueryRequest getByIdRegistrationQueryRequest)
    {
        GetByIdRegistrationQueryResponse response = await _mediator.Send(getByIdRegistrationQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Post([FromForm] CreateRegistrationCommandRequest createRegistrationCommandRequest)
    {
        CreateRegistrationCommandResponse response = await _mediator.Send(createRegistrationCommandRequest);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut("")]
    public async Task<IActionResult> Put([FromForm] UpdateRegistrationCommandRequest updateRegistrationCommandRequest)
    {
        UpdateRegistrationCommandResponse response = await _mediator.Send(updateRegistrationCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteRegistrationCommandRequest deleteRegistrationCommandRequest)
    {
        DeleteRegistrationCommandResponse response = await _mediator.Send(deleteRegistrationCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
