using MediatR;

namespace EHospital.Application.Features.Commands.Role.DeleteRole;

public class DeleteRoleCommandRequest:IRequest<DeleteRoleCommandResponse>
{
    public string? IdStr { get; set; }
}