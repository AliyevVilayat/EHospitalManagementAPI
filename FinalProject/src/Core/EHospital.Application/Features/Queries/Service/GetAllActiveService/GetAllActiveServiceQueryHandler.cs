using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Service.GetAllService;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetAllActiveService;

public class GetAllActiveServiceQueryHandler : IRequestHandler<GetAllActiveServiceQueryRequest, GetAllActiveServiceQueryResponse>
{
    private readonly IServiceService _serviceService;

    public GetAllActiveServiceQueryHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<GetAllActiveServiceQueryResponse> Handle(GetAllActiveServiceQueryRequest request, CancellationToken cancellationToken)
    {
        List<ServiceGetDTO> serviceGetDTOs = await _serviceService.GetAllActiveServicesAsync();
        GetAllActiveServiceQueryResponse response = new() { ServiceGetDTOs = serviceGetDTOs,ServicesCount=serviceGetDTOs.Count };
        return response;
    }
}
