using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Receptionist.GetAllActiveReceptionist;

public class GetAllActiveReceptionistQueryResponse
{
    public List<ReceptionistGetDTO> ReceptionistGetDTOs { get; set; }
    public long ReceptionistsCount { get; set; }
}
