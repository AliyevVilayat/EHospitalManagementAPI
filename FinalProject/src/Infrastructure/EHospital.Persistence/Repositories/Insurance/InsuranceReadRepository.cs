using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class InsuranceReadRepository : ReadRepository<Insurance>, IInsuranceReadRepository
{
    public InsuranceReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
