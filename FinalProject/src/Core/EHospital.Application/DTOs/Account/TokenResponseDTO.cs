namespace EHospital.Application.DTOs;

public class TokenResponseDTO
{
    public string? Token { get; set; }
    public string? Username { get; set; }
    public DateTime Expires { get; set; }
    public string? Messages { get; set; }
}
