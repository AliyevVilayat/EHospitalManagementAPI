using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class PatientReadRepository : ReadRepository<Patient>, IPatientReadRepository
{
    public PatientReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
