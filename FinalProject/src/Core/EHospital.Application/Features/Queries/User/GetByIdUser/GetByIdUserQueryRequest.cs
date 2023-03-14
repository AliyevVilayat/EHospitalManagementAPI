using MediatR;

namespace EHospital.Application.Features.Queries.User.GetByIdUser;

public class GetByIdUserQueryRequest:IRequest<GetByIdUserQueryResponse>
{
    public string? IdStr { get; set; }
}