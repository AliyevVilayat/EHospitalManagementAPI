using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Role.CreateRole;

public class CreateRoleCommandRequest:IRequest<CreateRoleCommandResponse>
{
    public RolePostDTO RolePostDTO { get; set; }
}