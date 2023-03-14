using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class RoomPostDTO
{
    public string? RoomCode { get; set; }
    public int Floor { get; set; }
    public Guid ServiceId { get; set; }
    public bool IsEmpty { get; set; }=true;
}
