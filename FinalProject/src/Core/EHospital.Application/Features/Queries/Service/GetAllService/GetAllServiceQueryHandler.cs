using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetAllService;

public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQueryRequest, GetAllServiceQueryResponse>
{
    private readonly IServiceService _serviceService;

    public GetAllServiceQueryHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<GetAllServiceQueryResponse> Handle(GetAllServiceQueryRequest request, CancellationToken cancellationToken)
    {
        List<ServiceGetDTO> serviceGetDTOs = await _serviceService.GetAllServicesAsync();
        GetAllServiceQueryResponse response = new() { ServiceGetDTOs = serviceGetDTOs, ServicesCount = serviceGetDTOs.Count };
        return response;
    }
}
