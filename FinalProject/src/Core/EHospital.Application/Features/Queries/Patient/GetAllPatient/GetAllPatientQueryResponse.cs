using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Patient.GetAllPatient;

public class GetAllPatientQueryResponse
{
    public List<PatientGetDTO> PatientGetDTOs { get; set; }
    public long PatientsCount { get; set; }
}
