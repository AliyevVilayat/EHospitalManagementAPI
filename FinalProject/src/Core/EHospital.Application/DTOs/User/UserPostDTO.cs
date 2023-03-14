namespace EHospital.Application.DTOs;

public class UserPostDTO
{
    public string? Fullname { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string? RoleIdStr { get; set; }

}
