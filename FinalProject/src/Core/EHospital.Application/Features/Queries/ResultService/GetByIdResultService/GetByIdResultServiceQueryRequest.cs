using MediatR;

namespace EHospital.Application.Features.Queries.ResultService.GetByIdResultService;

public class GetByIdResultServiceQueryRequest:IRequest<GetByIdResultServiceQueryResponse>
{
    public string? IdStr { get; set; }
}
