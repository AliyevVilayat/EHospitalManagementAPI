namespace EHospital.Application.DTOs;

public class RoomPutDTO
{
    public string? IdStr { get; set; }
    public string? RoomCode { get; set; }
    public int Floor { get; set; }
    public Guid ServiceId { get; set; }
    public bool IsEmpty { get; set; }
}
