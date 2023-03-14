using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IRoleService
{
    Task<List<RoleGetDTO>> GetAllRoleAsync();
    Task<RoleGetDTO> GetRoleByIdAsync(string id);
    Task<RoleGetDTO> GetRoleByNameAsync(string name);
    Task CreateRoleAsync(RolePostDTO rolePostDTO);
    Task UpdateRoleAsync(RolePutDTO rolePutDTO);
    Task DeleteRoleAsync(string id);
}
