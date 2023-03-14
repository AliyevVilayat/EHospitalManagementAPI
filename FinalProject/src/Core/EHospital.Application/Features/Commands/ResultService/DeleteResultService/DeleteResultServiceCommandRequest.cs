using MediatR;

namespace EHospital.Application.Features.Commands.ResultService.DeleteResultService;

public class DeleteResultServiceCommandRequest:IRequest<DeleteResultServiceCommandResponse>
{
    public string? IdStr { get; set; }
}
