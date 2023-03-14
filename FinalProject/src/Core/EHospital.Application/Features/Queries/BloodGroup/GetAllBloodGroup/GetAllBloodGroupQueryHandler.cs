using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.BloodGroup.GetAllBloodGroup;

public class GetAllBloodGroupQueryHandler : IRequestHandler<GetAllBloodGroupQueryRequest, GetAllBloodGroupQueryResponse>
{
    private readonly IBloodGroupService _bloodGroupService;

    public GetAllBloodGroupQueryHandler(IBloodGroupService bloodGroupService)
    {
        _bloodGroupService = bloodGroupService;
    }

    public async Task<GetAllBloodGroupQueryResponse> Handle(GetAllBloodGroupQueryRequest request, CancellationToken cancellationToken)
    {
        List<BloodGroupGetDTO> bloodGroupGetDTOs = await _bloodGroupService.GetAllBloodGroupAsync();
        GetAllBloodGroupQueryResponse response = new() { BloodGroupGetDTOs = bloodGroupGetDTOs,BloodGroupsCount=bloodGroupGetDTOs.Count };
        return response;
    }
}
