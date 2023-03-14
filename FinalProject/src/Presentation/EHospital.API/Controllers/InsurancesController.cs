using EHospital.Application.Features.Commands.Insurance.CreateInsurance;
using EHospital.Application.Features.Commands.Insurance.DeleteInsurance;
using EHospital.Application.Features.Commands.Insurance.UpdateInsurance;
using EHospital.Application.Features.Queries.Insurance.GetAllInsurance;
using EHospital.Application.Features.Queries.Insurance.GetByIdInsurance;
using EHospital.Application.Features.Queries.Insurance.GetByNameInsurance;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Receptionist,Moderator,Admin")]
public class InsurancesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InsurancesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Get([FromQuery] GetAllInsuranceQueryRequest getAllInsuranceQueryRequest)
    {
        GetAllInsuranceQueryResponse response = await _mediator.Send(getAllInsuranceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdInsuranceQueryRequest getByIdInsuranceQueryRequest)
    {
        GetByIdInsuranceQueryResponse response = await _mediator.Send(getByIdInsuranceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Name")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameInsuranceQueryRequest getByNameInsuranceQueryRequest)
    {
        GetByNameInsuranceQueryResponse response = await _mediator.Send(getByNameInsuranceQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Post([FromForm] CreateInsuranceCommandRequest createInsuranceCommandRequest)
    {

        CreateInsuranceCommandResponse response = await _mediator.Send(createInsuranceCommandRequest);

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Put([FromForm] UpdateInsuranceCommandRequest updateInsuranceCommandRequest)
    {
        UpdateInsuranceCommandResponse response = await _mediator.Send(updateInsuranceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete]
    //[Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Delete([FromForm] DeleteInsuranceCommandRequest deleteInsuranceCommandRequest)
    {
        DeleteInsuranceCommandResponse response = await _mediator.Send(deleteInsuranceCommandRequest);
        return StatusCode((int)HttpStatusCode.OK,response);
    }
}
