using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.ResultService.CreateResultService;

public class CreateResultServiceCommandRequest:IRequest<CreateResultServiceCommandResponse>
{
    public ResultServicePostDTO ResultServicePostDTO { get; set; }
}
