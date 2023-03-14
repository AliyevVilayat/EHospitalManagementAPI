using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Service.GetByNameService;

public class GetByNameServiceQueryHandler : IRequestHandler<GetByNameServiceQueryRequest, GetByNameServiceQueryResponse>
{
    private readonly IServiceService _serviceService;

    public GetByNameServiceQueryHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<GetByNameServiceQueryResponse> Handle(GetByNameServiceQueryRequest request, CancellationToken cancellationToken)
    {
        List<ServiceGetDTO> serviceGetDTOs = await _serviceService.GetServiceByNameAsync(request.Page, request.Size, request.Name);
        GetByNameServiceQueryResponse response = new() { ServiceGetDTOs= serviceGetDTOs, ServicesCount = serviceGetDTOs.Count };
        return response;
    }
}
