using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class RegistrationReadRepository : ReadRepository<Registration>, IRegistrationReadRepository
{
    public RegistrationReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
