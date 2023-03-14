using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Role.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
    {
        await _roleService.DeleteRoleAsync(request.IdStr);
        DeleteRoleCommandResponse response = new() { Message = "Role successfully deleted" };
        return response;
    }
}
