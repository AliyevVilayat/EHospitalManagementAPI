using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class ServiceGetDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public float Cost { get; set; }
    public FieldServiceGetDTO FieldServiceGetDTO { get; set; }
    public ICollection<RoomDTO> RoomDTOs { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    
}
