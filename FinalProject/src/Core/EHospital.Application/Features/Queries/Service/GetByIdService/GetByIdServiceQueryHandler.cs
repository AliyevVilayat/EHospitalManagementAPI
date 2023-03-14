using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetByIdService;

public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQueryRequest, GetByIdServiceQueryResponse>
{
    private readonly IServiceService _serviceService;

    public GetByIdServiceQueryHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<GetByIdServiceQueryResponse> Handle(GetByIdServiceQueryRequest request, CancellationToken cancellationToken)
    {
        ServiceGetDTO serviceGetDTO = await _serviceService.GetServiceByIdAsync(request.Id);
        GetByIdServiceQueryResponse response = new() { ServiceGetDTO = serviceGetDTO };
        return response;
    }
}
