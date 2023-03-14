using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class RoomGetDTO
{
    public Guid Id { get; set; }
    public string? RoomCode { get; set; }
    public int Floor { get; set; }
    public ServiceGetDTO ServiceGetDTO { get; set; }
    public bool IsEmpty { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }

}
