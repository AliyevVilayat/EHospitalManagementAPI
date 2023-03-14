using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.BloodGroup.GetByIdBloodGroup;

public class GetByIdBloodGroupQueryHandler:IRequestHandler<GetByIdBloodGroupQueryRequest, GetByIdBloodGroupQueryResponse>
{
    private readonly IBloodGroupService _bloodGroupService;

    public GetByIdBloodGroupQueryHandler(IBloodGroupService bloodGroupService)
    {
        _bloodGroupService = bloodGroupService;
    }

    public async Task<GetByIdBloodGroupQueryResponse> Handle(GetByIdBloodGroupQueryRequest request, CancellationToken cancellationToken)
    {
        BloodGroupGetDTO bloodGroupGetDTO = await _bloodGroupService.GetBloodGroupByIdAsync(request.Id);
        GetByIdBloodGroupQueryResponse response = new() { BloodGroupGetDTO = bloodGroupGetDTO };
        return response;
    }
}
