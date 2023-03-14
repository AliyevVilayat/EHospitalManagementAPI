using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class PatientWriteRepository : WriteRepository<Patient>, IPatientWriteRepository
{
    public PatientWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
