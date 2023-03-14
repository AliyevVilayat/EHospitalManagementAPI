using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class GenderReadRepository : ReadRepository<Gender>, IGenderReadRepository
{
    public GenderReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
