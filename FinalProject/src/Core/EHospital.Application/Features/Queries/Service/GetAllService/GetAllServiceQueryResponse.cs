using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Service.GetAllService;

public class GetAllServiceQueryResponse
{
    public List<ServiceGetDTO> ServiceGetDTOs { get; set; }
    public long ServicesCount { get; set; }
}
