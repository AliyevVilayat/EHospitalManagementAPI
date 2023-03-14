using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.ResultService.GetAllResultService;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.ResultService.GetByIdResultService;

public class GetByIdResultServiceQueryHandler : IRequestHandler<GetByIdResultServiceQueryRequest, GetByIdResultServiceQueryResponse>
{
    private readonly IResultServiceService _resultServiceService;

    public GetByIdResultServiceQueryHandler(IResultServiceService resultServiceService)
    {
        _resultServiceService = resultServiceService;
    }
    public async Task<GetByIdResultServiceQueryResponse> Handle(GetByIdResultServiceQueryRequest request, CancellationToken cancellationToken)
    {
        ResultServiceGetDTO resultServiceGetDTO = await _resultServiceService.GetResultServiceByIdAsync(request.IdStr);
        GetByIdResultServiceQueryResponse response = new() { ResultServiceGetDTO = resultServiceGetDTO };
        return response;
    }
}
