using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Role.GetAllRole;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Role.GetByIdRole;

public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, GetByIdRoleQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetByIdRoleQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
    {
        RoleGetDTO roleGetDTO = await _roleService.GetRoleByIdAsync(request.IdStr);
        GetByIdRoleQueryResponse response = new() { RoleGetDTO = roleGetDTO };
        return response;
    }
}
