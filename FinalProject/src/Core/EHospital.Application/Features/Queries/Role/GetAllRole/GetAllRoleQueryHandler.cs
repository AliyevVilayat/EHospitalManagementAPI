using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Role.GetAllRole;

public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetAllRoleQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
    {
        List<RoleGetDTO> roleGetDTOs = await _roleService.GetAllRoleAsync();
        GetAllRoleQueryResponse response = new() { RoleGetDTOs = roleGetDTOs,RolesCount=roleGetDTOs.Count };
        return response;
    }
}
