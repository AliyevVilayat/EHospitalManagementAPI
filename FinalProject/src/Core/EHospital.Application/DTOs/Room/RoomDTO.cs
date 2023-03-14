namespace EHospital.Application.DTOs;

public class RoomDTO
{
    public Guid Id { get; set; }
    public string? RoomCode { get; set; }
    public int Floor { get; set; }
    public bool IsEmpty { get; set; }
}
