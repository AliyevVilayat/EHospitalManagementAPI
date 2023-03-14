using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class ResultServiceGetDTO
{
    public Guid Id { get; set; }
    public string? Result { get; set; }
    public RegistrationDTO RegistrationDTO { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
