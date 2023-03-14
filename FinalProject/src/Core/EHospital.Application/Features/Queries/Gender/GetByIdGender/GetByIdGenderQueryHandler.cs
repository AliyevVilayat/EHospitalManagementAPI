using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Gender.GetByIdGender;

public class GetByIdGenderQueryHandler : IRequestHandler<GetByIdGenderQueryRequest, GetByIdGenderQueryResponse>
{
    private readonly IGenderService _genderService;

    public GetByIdGenderQueryHandler(IGenderService genderService)
    {
        _genderService = genderService;
    }

    public async Task<GetByIdGenderQueryResponse> Handle(GetByIdGenderQueryRequest request, CancellationToken cancellationToken)
    {
        GenderGetDTO genderGetDTO = await _genderService.GetGenderByIdAsync(request.Id);
        GetByIdGenderQueryResponse response = new() { GenderGetDTO = genderGetDTO };
        return response;
    }
}
