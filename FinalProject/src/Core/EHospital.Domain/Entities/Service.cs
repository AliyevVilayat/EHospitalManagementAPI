using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Service:BaseEntity
{
    public string? Name { get; set; }
    public Guid FieldId { get; set; }
    public Field Field { get; set; }
    public float Cost { get; set; }

    public ICollection<Room> Rooms { get; set; }
    public ICollection<Registration> Registrations { get; set; }
}
