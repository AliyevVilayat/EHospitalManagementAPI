using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.ResultService.GetAllActiveResultService;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.ResultService.GetAllResultService;

public class GetAllResultServiceQueryHandler : IRequestHandler<GetAllResultServiceQueryRequest, GetAllResultServiceQueryResponse>
{
    private readonly IResultServiceService _resultServiceService;

    public GetAllResultServiceQueryHandler(IResultServiceService resultServiceService)
    {
        _resultServiceService = resultServiceService;
    }
    public async Task<GetAllResultServiceQueryResponse> Handle(GetAllResultServiceQueryRequest request, CancellationToken cancellationToken)
    {
        List<ResultServiceGetDTO> resultServiceGetDTOs = await _resultServiceService.GetAllResultServiceAsync();
        GetAllResultServiceQueryResponse response = new() { ResultServiceGetDTOs = resultServiceGetDTOs,ResultServicesCount=resultServiceGetDTOs.Count };
        return response;
    }
}
