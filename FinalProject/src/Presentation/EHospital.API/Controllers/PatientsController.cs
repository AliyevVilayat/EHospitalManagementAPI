using EHospital.Application.Features.Commands.Patient.CreatePatient;
using EHospital.Application.Features.Commands.Patient.DeletePatient;
using EHospital.Application.Features.Commands.Patient.UpdatePatient;
using EHospital.Application.Features.Queries.Patient.GetAllActivePatient;
using EHospital.Application.Features.Queries.Patient.GetAllPatient;
using EHospital.Application.Features.Queries.Patient.GetByIdPatient;
using EHospital.Application.Features.Queries.Patient.GetByNamePatient;
using EHospital.Application.Features.Queries.Patient.GetBySeriaNumberPatient;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Receptionist,Moderator,Admin")]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllPatientQueryRequest getAllPatientQueryRequest)
    {
        GetAllPatientQueryResponse response = await _mediator.Send(getAllPatientQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActivePatientQueryRequest getAllActivePatientQueryRequest)
    {
        GetAllActivePatientQueryResponse response = await _mediator.Send(getAllActivePatientQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdPatientQueryRequest getByIdPatientQueryRequest)
    {
        GetByIdPatientQueryResponse response = await _mediator.Send(getByIdPatientQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNamePatientQueryRequest getByNamePatientQueryRequest)
    {
        GetByNamePatientQueryResponse response = await _mediator.Send(getByNamePatientQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("SeriaNumber")]
    public async Task<IActionResult> GetBySeriaNumber([FromQuery] GetBySeriaNumberPatientQueryRequest getBySeriaNumberPatientQueryRequest)
    {
        GetBySeriaNumberPatientQueryResponse response = await _mediator.Send(getBySeriaNumberPatientQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreatePatientCommandRequest createPatientCommandRequest)
    {

        CreatePatientCommandResponse response = await _mediator.Send(createPatientCommandRequest);

        return StatusCode((int)HttpStatusCode.Created,response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromForm] UpdatePatientCommandRequest updatePatientCommandRequest)
    {
        UpdatePatientCommandResponse response = await _mediator.Send(updatePatientCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeletePatientCommandRequest deletePatientCommandRequest)
    {
        DeletePatientCommandResponse response = await _mediator.Send(deletePatientCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

}
