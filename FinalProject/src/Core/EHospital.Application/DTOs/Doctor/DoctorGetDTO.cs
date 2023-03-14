using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class DoctorGetDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DOB { get; set; }
    public GenderDTO GenderDTO { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SeriaNumber { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public int ExperienceYear { get; set; }
    public FieldDoctorGetDTO FieldDoctorGetDTO { get; set; }
    public float Salary { get; set; }
    public string? VOEN { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
