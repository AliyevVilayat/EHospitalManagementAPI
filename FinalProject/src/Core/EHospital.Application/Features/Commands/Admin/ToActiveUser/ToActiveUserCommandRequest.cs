using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveUser;

public class ToActiveUserCommandRequest:IRequest<ToActiveUserCommandResponse>
{
    public string? Id { get; set; }
}