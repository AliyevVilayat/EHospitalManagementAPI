namespace EHospital.Application.DTOs;

public class UserGetDTO
{
    public string? Id { get; set; }
    public string? Fullname { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? RoleName { get; set; }
    public string? RoleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
