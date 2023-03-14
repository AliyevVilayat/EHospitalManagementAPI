using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class FieldServiceGetDTO
{
    public Guid Id { get; set; }
    public string? PersonField { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}
