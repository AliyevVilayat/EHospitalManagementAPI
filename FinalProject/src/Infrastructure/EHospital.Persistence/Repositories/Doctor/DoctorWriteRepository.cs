using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class DoctorWriteRepository : WriteRepository<Doctor>, IDoctorWriteRepository
{
    public DoctorWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
