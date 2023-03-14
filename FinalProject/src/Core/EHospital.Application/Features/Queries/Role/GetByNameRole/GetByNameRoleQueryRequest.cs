using MediatR;

namespace EHospital.Application.Features.Queries.Role.GetByNameRole
{
    public class GetByNameRoleQueryRequest:IRequest<GetByNameRoleQueryResponse>
    {
        public string? Name { get; set; }
    }
}