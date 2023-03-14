using EHospital.Application.Features.Commands.Admin.ToActiveDoctor;
using EHospital.Application.Features.Commands.Admin.ToActiveField;
using EHospital.Application.Features.Commands.Admin.ToActiveInsurance;
using EHospital.Application.Features.Commands.Admin.ToActivePatient;
using EHospital.Application.Features.Commands.Admin.ToActiveReceptionist;
using EHospital.Application.Features.Commands.Admin.ToActiveRoom;
using EHospital.Application.Features.Commands.Admin.ToActiveService;
using EHospital.Application.Features.Commands.Admin.ToActiveUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("doctor")]
    public async Task<IActionResult> ToActiveDoctor(ToActiveDoctorCommandRequest toActiveDoctorCommandRequest)
    {
        ToActiveDoctorCommandResponse response = await _mediator.Send(toActiveDoctorCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }

    [HttpPut("field")]
    public async Task<IActionResult> ToActiveField(ToActiveFieldCommandRequest toActiveFieldCommandRequest)
    {
        ToActiveFieldCommandResponse response = await _mediator.Send(toActiveFieldCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("patient")]
    public async Task<IActionResult> ToActivePatient(ToActivePatientCommandRequest toActivePatientCommandRequest)
    {
        ToActivePatientCommandResponse response = await _mediator.Send(toActivePatientCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("service")]
    public async Task<IActionResult> ToActiveService(ToActiveServiceCommandRequest toActiveServiceCommandRequest)
    {
        ToActiveServiceCommandResponse response = await _mediator.Send(toActiveServiceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("Insurance")]
    public async Task<IActionResult> ToActiveInsurance(ToActiveInsuranceCommandRequest toActiveInsuranceCommandRequest)
    {
        ToActiveInsuranceCommandResponse response = await _mediator.Send(toActiveInsuranceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("receptionist")]
    public async Task<IActionResult> ToActiveReceptionist(ToActiveReceptionistCommandRequest toActiveReceptionistCommandRequest)
    {
        ToActiveReceptionistCommandResponse response = await _mediator.Send(toActiveReceptionistCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("room")]
    public async Task<IActionResult> ToActiveRoom(ToActiveRoomCommandRequest toActiveRoomCommandRequest)
    {
        ToActiveRoomCommandResponse response = await _mediator.Send(toActiveRoomCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("user")]
    public async Task<IActionResult> ToActiveUser(ToActiveUserCommandRequest toActiveUserCommandRequest)
    {
        ToActiveUserCommandResponse response = await _mediator.Send(toActiveUserCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
