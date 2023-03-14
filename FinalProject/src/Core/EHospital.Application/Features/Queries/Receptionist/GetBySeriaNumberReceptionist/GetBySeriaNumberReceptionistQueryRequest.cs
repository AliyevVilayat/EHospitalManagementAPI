using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetBySeriaNumberReceptionist;

public class GetBySeriaNumberReceptionistQueryRequest:IRequest<GetBySeriaNumberReceptionistQueryResponse>
{
    public string? SeriaNumber { get; set; }
}
