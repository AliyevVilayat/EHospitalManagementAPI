using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IUserService
{
    Task<List<UserGetDTO>> GetAllUserAsync();
    Task<List<UserGetDTO>> GetAllActiveUserAsync();
    Task<UserGetDTO> GetUserByIdAsync(string id);
    Task<UserGetDTO> GetUserByUserNameAsync(string username);
    Task CreateUserAsync(UserPostDTO userPostDTO);
    Task DeleteUserAsync(string id);
    Task HardDeleteUserAsync(string id);   
}
