using MediatR;

namespace EHospital.Application.Features.Queries.Role.GetByIdRole;

public class GetByIdRoleQueryRequest:IRequest<GetByIdRoleQueryResponse>
{
    public string? IdStr { get; set; }
}