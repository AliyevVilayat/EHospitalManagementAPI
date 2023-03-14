using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetByIdService;

public class GetByIdServiceQueryRequest:IRequest<GetByIdServiceQueryResponse>
{
    public string? Id { get; set; }
}
