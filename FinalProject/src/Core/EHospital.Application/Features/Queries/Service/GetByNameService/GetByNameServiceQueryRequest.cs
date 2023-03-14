using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetByNameService;

public class GetByNameServiceQueryRequest:IRequest<GetByNameServiceQueryResponse>
{
    public string? Name { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}
