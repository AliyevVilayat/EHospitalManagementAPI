using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class InsuranceWriteRepository : WriteRepository<Insurance>, IInsuranceWriteRepository
{
    public InsuranceWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
