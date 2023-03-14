using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class DoctorPostDTO
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DOB { get; set; }
    public string? GenderIdStr { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SeriaNumber { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public int ExperienceYear { get; set; }
    public string? FieldIdStr { get; set; }
    public float Salary { get; set; }
    public string? VOEN { get; set; }
    public string? Email { get; set; }
}
