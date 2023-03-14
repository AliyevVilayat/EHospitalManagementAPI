using EHospital.Application.Features.Commands.Role.DeleteRole;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Role.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        await _roleService.UpdateRoleAsync(request.RolePutDTO);
        UpdateRoleCommandResponse response = new() { Message = "Role successfully updated" };
        return response;
    }
}
