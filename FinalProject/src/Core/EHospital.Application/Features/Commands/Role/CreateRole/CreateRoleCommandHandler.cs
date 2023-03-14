using EHospital.Application.Features.Commands.Role.DeleteRole;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Role.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        await _roleService.CreateRoleAsync(request.RolePostDTO);
        CreateRoleCommandResponse response = new() { Message = "Role successfully created" };
        return response;
    }
}
