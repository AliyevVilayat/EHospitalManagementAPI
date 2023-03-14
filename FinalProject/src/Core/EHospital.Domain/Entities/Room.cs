using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Room : BaseEntity
{
    public string? RoomCode { get; set; }
    public int Floor { get; set; }
    public Guid ServiceId { get; set; }
    public Service Service { get; set; }
    public bool IsEmpty { get; set; } = true;
    public ICollection<Registration> Registrations { get; set; }
}
