using MediatR;

namespace EHospital.Application.Features.Queries.Insurance.GetByNameInsurance;

public class GetByNameInsuranceQueryRequest:IRequest<GetByNameInsuranceQueryResponse>
{
    public string? Name { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}
