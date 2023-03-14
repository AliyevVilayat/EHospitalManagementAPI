using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class ResultService:BaseEntity
{
    public string? Result { get; set; }
    public Guid RegistrationId { get; set; }
    public Registration Registration { get; set; }
}
