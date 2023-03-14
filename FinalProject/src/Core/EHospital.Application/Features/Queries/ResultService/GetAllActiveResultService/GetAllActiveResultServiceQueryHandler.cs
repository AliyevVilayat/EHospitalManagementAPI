using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.ResultService.GetAllActiveResultService;

public class GetAllActiveResultServiceQueryHandler : IRequestHandler<GetAllActiveResultServiceQueryRequest, GetAllActiveResultServiceQueryResponse>
{
    private readonly IResultServiceService _resultServiceService;

    public GetAllActiveResultServiceQueryHandler(IResultServiceService resultServiceService)
    {
        _resultServiceService = resultServiceService;
    }
    public async Task<GetAllActiveResultServiceQueryResponse> Handle(GetAllActiveResultServiceQueryRequest request, CancellationToken cancellationToken)
    {
        List<ResultServiceGetDTO> resultServiceGetDTOs = await _resultServiceService.GetAllActiveResultServiceAsync();
        GetAllActiveResultServiceQueryResponse response = new() { ResultServiceGetDTOs = resultServiceGetDTOs, ResultServicesCount = resultServiceGetDTOs.Count };
        return response;
    }
}
