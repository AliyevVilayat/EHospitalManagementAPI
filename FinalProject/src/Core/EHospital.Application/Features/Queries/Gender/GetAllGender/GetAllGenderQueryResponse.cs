using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Gender.GetAllGender;

public class GetAllGenderQueryResponse
{
    public List<GenderGetDTO> GenderGetDTOs { get; set; }
    public long GendersCount { get; set; }
}
