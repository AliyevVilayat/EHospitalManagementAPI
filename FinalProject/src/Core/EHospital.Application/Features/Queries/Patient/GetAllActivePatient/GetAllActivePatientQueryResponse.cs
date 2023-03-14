using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Patient.GetAllActivePatient;

public class GetAllActivePatientQueryResponse
{
    public List<PatientGetDTO> PatientGetDTOs { get; set; }
    public long PatientsCount { get; set; }
}
