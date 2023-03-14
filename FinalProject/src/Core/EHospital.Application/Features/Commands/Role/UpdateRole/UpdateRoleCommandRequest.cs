using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Role.UpdateRole;

public class UpdateRoleCommandRequest:IRequest<UpdateRoleCommandResponse>
{
    public RolePutDTO RolePutDTO { get; set; }
}