using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Role.GetAllRole;

public class GetAllRoleQueryResponse
{
    public List<RoleGetDTO> RoleGetDTOs { get; set; }
    public long RolesCount { get; set; }
}