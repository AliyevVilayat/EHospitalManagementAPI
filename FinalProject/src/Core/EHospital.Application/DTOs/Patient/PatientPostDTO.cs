using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class PatientPostDTO
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DOB { get; set; }
    public string? GenderIdStr { get; set; }
    public string? BloodGroupIdStr { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SeriaNumber { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public string? InsuranceIdStr { get; set; }
    public string? Email { get; set; }
}
