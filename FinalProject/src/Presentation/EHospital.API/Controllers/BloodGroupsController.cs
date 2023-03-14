using EHospital.Application.Features.Queries.BloodGroup.GetAllBloodGroup;
using EHospital.Application.Features.Queries.BloodGroup.GetByIdBloodGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BloodGroupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodGroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery] GetAllBloodGroupQueryRequest getAllBloodGroupQueryRequest)
    {
        GetAllBloodGroupQueryResponse response = await _mediator.Send(getAllBloodGroupQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdBloodGroupQueryRequest getByIdBloodGroupQueryRequest)
    {
        GetByIdBloodGroupQueryResponse response = await _mediator.Send(getByIdBloodGroupQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
