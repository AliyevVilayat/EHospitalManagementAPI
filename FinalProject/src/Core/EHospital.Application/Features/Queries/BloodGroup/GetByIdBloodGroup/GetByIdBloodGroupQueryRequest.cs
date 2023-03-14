using MediatR;

namespace EHospital.Application.Features.Queries.BloodGroup.GetByIdBloodGroup;

public class GetByIdBloodGroupQueryRequest:IRequest<GetByIdBloodGroupQueryResponse>
{
    public string? Id { get; set; }
}
