using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Service.GetAllActiveService;

public class GetAllActiveServiceQueryResponse
{
    public List<ServiceGetDTO> ServiceGetDTOs { get; set; }
    public long ServicesCount { get; set; }
}
