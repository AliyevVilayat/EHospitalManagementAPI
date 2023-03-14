using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class FieldDoctorGetDTO
{
    public Guid Id { get; set; }
    public string? PersonField { get; set; }
    public ICollection<Service> Services { get; set; }
}
