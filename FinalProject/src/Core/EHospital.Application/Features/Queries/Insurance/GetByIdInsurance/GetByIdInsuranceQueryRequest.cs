using MediatR;

namespace EHospital.Application.Features.Queries.Insurance.GetByIdInsurance;

public class GetByIdInsuranceQueryRequest : IRequest<GetByIdInsuranceQueryResponse>
{
    public string? Id { get; set; }
}
