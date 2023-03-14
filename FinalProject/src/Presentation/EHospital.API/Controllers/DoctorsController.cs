using EHospital.Application.Features.Commands.Doctor.CreateDoctor;
using EHospital.Application.Features.Commands.Doctor.DeleteDoctor;
using EHospital.Application.Features.Commands.Doctor.UpdateDoctor;
using EHospital.Application.Features.Queries.Doctor.GetAllActiveDoctor;
using EHospital.Application.Features.Queries.Doctor.GetAllDoctor;
using EHospital.Application.Features.Queries.Doctor.GetByIdDoctor;
using EHospital.Application.Features.Queries.Doctor.GetByNameDoctor;
using EHospital.Application.Features.Queries.Doctor.GetBySeriaNumberPatient;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Receptionist,Moderator,Admin")]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllDoctorQueryRequest getAllDoctorQueryRequest)
    {
        GetAllDoctorQueryResponse response = await _mediator.Send(getAllDoctorQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Active")]
    public async Task<IActionResult> GetAllActive([FromQuery] GetAllActiveDoctorQueryRequest getAllActiveDoctorQueryRequest)
    {
        GetAllActiveDoctorQueryResponse response = await _mediator.Send(getAllActiveDoctorQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdDoctorQueryRequest getByIdDoctorQueryRequest)
    {
        GetByIdDoctorQueryResponse response = await _mediator.Send(getByIdDoctorQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameDoctorQueryRequest getByNameDoctorQueryRequest)
    {
        GetByNameDoctorQueryResponse response = await _mediator.Send(getByNameDoctorQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("SeriaNumber")]
    public async Task<IActionResult> GetBySeriaNumber([FromQuery] GetBySeriaNumberDoctorQueryRequest getBySeriaNumberDoctorQueryRequest)
    {
        GetBySeriaNumberDoctorQueryResponse response = await _mediator.Send(getBySeriaNumberDoctorQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Post([FromForm] CreateDoctorCommandRequest createDoctorCommandRequest)
    {
        CreateDoctorCommandResponse response = await _mediator.Send(createDoctorCommandRequest);
        return StatusCode((int)HttpStatusCode.Created,response);
    }

    [HttpPut("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Put([FromForm] UpdateDoctorCommandRequest updateDoctorCommandRequest)
    {
        UpdateDoctorCommandResponse response =  await _mediator.Send(updateDoctorCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }

    [HttpDelete("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteDoctorCommandRequest deleteDoctorCommandRequest)
    {
        DeleteDoctorCommandResponse response = await _mediator.Send(deleteDoctorCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }
}
