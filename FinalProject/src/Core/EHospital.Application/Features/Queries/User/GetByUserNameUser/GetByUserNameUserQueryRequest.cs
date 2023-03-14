using MediatR;

namespace EHospital.Application.Features.Queries.User.GetByUserNameUser;

public class GetByUserNameUserQueryRequest:IRequest<GetByUserNameUserQueryResponse>
{
    public string? UserName { get; set; }
}