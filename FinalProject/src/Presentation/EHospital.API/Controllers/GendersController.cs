using EHospital.Application.Features.Queries.Gender.GetAllGender;
using EHospital.Application.Features.Queries.Gender.GetByIdGender;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GendersController : ControllerBase
{
    private readonly IMediator _mediator;

    public GendersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery] GetAllGenderQueryRequest getAllGenderQueryRequest)
    {
        GetAllGenderQueryResponse response = await _mediator.Send(getAllGenderQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdGenderQueryRequest getByIdGenderQueryRequest)
    {
        GetByIdGenderQueryResponse response = await _mediator.Send(getByIdGenderQueryRequest);
        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
