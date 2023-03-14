using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Gender.GetAllGender;

public class GetAllGenderQueryHandler : IRequestHandler<GetAllGenderQueryRequest, GetAllGenderQueryResponse>
{
    private readonly IGenderService _genderService;

    public GetAllGenderQueryHandler(IGenderService genderService)
    {
        _genderService = genderService;
    }

    public async Task<GetAllGenderQueryResponse> Handle(GetAllGenderQueryRequest request, CancellationToken cancellationToken)
    {
        List<GenderGetDTO> genderGetDTOs = await _genderService.GetAllGenderAsync();
        GetAllGenderQueryResponse response = new() { GenderGetDTOs = genderGetDTOs,GendersCount= genderGetDTOs.Count };
        return response;
    }
}
