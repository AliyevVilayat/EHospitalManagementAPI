using MediatR;

namespace EHospital.Application.Features.Queries.Field.GetByIdField;

public class GetByIdFieldQueryRequest:IRequest<GetByIdFieldQueryResponse>
{
    public string? Id { get; set; }
}
