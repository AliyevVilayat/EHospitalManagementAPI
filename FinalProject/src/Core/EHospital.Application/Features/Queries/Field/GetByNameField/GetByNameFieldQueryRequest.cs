using MediatR;

namespace EHospital.Application.Features.Queries.Field.GetByNameField;

public class GetByNameFieldQueryRequest:IRequest<GetByNameFieldQueryResponse>
{
    public string? Name { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}
