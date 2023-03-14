using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.BloodGroup.GetAllBloodGroup;

public class GetAllBloodGroupQueryResponse
{
    public List<BloodGroupGetDTO> BloodGroupGetDTOs { get; set; }
    public long BloodGroupsCount { get; set; }
}
