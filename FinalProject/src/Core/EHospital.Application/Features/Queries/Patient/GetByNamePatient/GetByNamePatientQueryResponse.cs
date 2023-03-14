using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Patient.GetByNamePatient;

public class GetByNamePatientQueryResponse
{
    public List<PatientGetDTO> PatientGetDTOs { get; set; }
    public long PatientsCount { get; set; }
}
