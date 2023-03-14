using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class FieldReadRepository : ReadRepository<Field>, IFieldReadRepository
{
    public FieldReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
