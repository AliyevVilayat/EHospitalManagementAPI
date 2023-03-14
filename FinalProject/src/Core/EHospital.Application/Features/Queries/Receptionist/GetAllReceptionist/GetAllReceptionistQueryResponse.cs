using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Receptionist.GetAllReceptionist;

public class GetAllReceptionistQueryResponse
{
    public List<ReceptionistGetDTO> ReceptionistGetDTOs { get; set; }
    public long ReceptionistsCount { get; set; }
}
