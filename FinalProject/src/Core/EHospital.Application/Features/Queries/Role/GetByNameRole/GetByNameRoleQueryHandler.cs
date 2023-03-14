using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Role.GetByIdRole;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Role.GetByNameRole;

public class GetByNameRoleQueryHandler : IRequestHandler<GetByNameRoleQueryRequest, GetByNameRoleQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetByNameRoleQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<GetByNameRoleQueryResponse> Handle(GetByNameRoleQueryRequest request, CancellationToken cancellationToken)
    {
        RoleGetDTO roleGetDTO = await _roleService.GetRoleByNameAsync(request.Name);
        GetByNameRoleQueryResponse response = new() { RoleGetDTO = roleGetDTO };
        return response;
    }
}
