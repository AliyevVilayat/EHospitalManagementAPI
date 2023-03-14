using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.ResultService.GetAllResultService;

public class GetAllResultServiceQueryResponse
{
    public List<ResultServiceGetDTO> ResultServiceGetDTOs { get; set; }
    public long ResultServicesCount { get; set; }
}
