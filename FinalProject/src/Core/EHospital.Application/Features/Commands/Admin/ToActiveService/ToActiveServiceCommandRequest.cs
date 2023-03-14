using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveService;

public class ToActiveServiceCommandRequest:IRequest<ToActiveServiceCommandResponse>
{
    public string? Id { get; set; }

}