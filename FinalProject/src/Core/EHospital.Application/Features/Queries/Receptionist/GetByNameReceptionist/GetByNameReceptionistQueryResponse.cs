using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Receptionist.GetByNameReceptionist;

public class GetByNameReceptionistQueryResponse
{
    public List<ReceptionistGetDTO> ReceptionistGetDTOs { get; set; }
    public long ReceptionistsCount { get; set; }
}
