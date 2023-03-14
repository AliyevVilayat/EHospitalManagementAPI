using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetByNameService;

public class GetByNameServiceQueryResponse
{
    public List<ServiceGetDTO> ServiceGetDTOs { get; set; }
    public long ServicesCount { get; set; }
}
