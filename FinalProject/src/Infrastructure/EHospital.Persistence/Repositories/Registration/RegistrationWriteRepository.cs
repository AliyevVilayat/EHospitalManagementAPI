using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class RegistrationWriteRepository : WriteRepository<Registration>, IRegistrationWriteRepository
{
    public RegistrationWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
