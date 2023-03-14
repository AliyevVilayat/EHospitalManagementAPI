using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetByIdReceptionist;

public class GetByIdReceptionistQueryRequest:IRequest<GetByIdReceptionistQueryResponse>
{
    public string? IdStr { get; set; }
}
