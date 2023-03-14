using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.ResultService.GetAllActiveResultService;

public class GetAllActiveResultServiceQueryResponse
{
    public List<ResultServiceGetDTO> ResultServiceGetDTOs { get; set; }
    public long ResultServicesCount { get; set; }
}
