using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.ResultService.UpdateResultService;

public class UpdateResultServiceCommandRequest:IRequest<UpdateResultServiceCommandResponse>
{
    public ResultServicePutDTO ResultServicePutDTO { get; set; }
}
