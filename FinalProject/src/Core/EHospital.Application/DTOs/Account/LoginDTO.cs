namespace EHospital.Application.DTOs;

public class LoginDTO
{
    public string? UsernameOrEmail { get; set; }
    public string? Password { get; set; }
    public bool RememberMe { get; set; }    
}
