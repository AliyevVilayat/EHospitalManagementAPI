using MediatR;

namespace EHospital.Application.Features.Queries.Room.GetByCodeRoom;

public class GetByCodeRoomQueryRequest:IRequest<GetByCodeRoomQueryResponse>
{
    public string? Code { get; set; }
}
