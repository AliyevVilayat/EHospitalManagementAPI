using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetByIdRoom;

public class GetByIdRoomQueryRequest:IRequest<GetByIdRoomQueryResponse>
{
    public string? IdStr { get; set; }
}
