using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetByNameReceptionist;

public class GetByNameReceptionistQueryRequest:IRequest<GetByNameReceptionistQueryResponse>
{
    public string? Name { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}
