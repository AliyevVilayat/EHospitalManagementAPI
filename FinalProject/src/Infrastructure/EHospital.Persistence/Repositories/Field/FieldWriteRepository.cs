using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class FieldWriteRepository : WriteRepository<Field>, IFieldWriteRepository
{
    public FieldWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
