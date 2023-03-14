namespace EHospital.Application.DTOs;

public class ResetPasswordDTO
{
    public string? Id { get; set; }
    public string? ResetToken { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}
