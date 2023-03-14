using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class ServiceReadRepository : ReadRepository<Service>, IServiceReadRepository
{
    public ServiceReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
