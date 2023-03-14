using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class BloodGroupReadRepository : ReadRepository<BloodGroup>, IBloodGroupReadRepository
{
    public BloodGroupReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
